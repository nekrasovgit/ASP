using System;
using System.Collections.Concurrent;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using DNekrasovDB.Data.UnitOfWork;
using DNekrasovDB.Data.NewsParser;
using DNekrasovDB.Data.RssReader;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using DNekrasovDB.Models.DB;
using System.Reflection;

namespace DNekrasovDB.Data.NewsService
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRssReader _rssReader;
        private readonly IOnlinerParser _onlinerParser;
        private readonly ITutByParser _tutByParser;
        private readonly IS13Parser _s13Parser;
        private readonly ILogger _logger;

        public NewsService(IUnitOfWork unitOfWork, IRssReader rssReader, IOnlinerParser onlinerParser,
            ITutByParser tutByParser, IS13Parser s13Parser)
        {
            _unitOfWork = unitOfWork;
            _rssReader = rssReader;
            _onlinerParser = onlinerParser;
            _tutByParser = tutByParser;
            _s13Parser = s13Parser;

        }

        //todo create method in interface for get InsertNewsFromRssToDb

        public async Task InsertNewsFromRssToDb()
        {
            var urls = GetUrlsFromRss();

            var news = GetNewsFromUrls(urls);

            await _unitOfWork.NewsRepository.AddRangeasync(news);
        }

        public async Task<IEnumerable<News>> GetAvailableNews()
        {
            return (await _unitOfWork.NewsRepository.GetAllAsync()).ToList();
        }

        //todo to private
        private IEnumerable<News> GetNewsFromUrls(IEnumerable<string> urls)

        {
            try
            {

                //split urls for different parsers or use fabric urlsFromRss
                var urlFromRss = GetUrlsFromRss();

                var onlinerUrls = urlFromRss.Where(si =>
                    si.ToLowerInvariant().Contains("onliner")).ToList();

                /*var tuByUrls = urlFromRss.Where(si =>
                    si.ToLowerInvariant().Contains("tutby")).ToList();

                var s13Urls = urlFromRss.Where(si =>
                    si.ToLowerInvariant().Contains("s13")).ToList();*/

                var news = new ConcurrentBag<News>();

                Parallel.ForEach(onlinerUrls, url =>
                {
                    news.Add(_onlinerParser.Parse(url));
                });

                /*Parallel.ForEach(tuByUrls, url =>
                {
                    news.Add(_tutByParser.Parse(url));
                });

                Parallel.ForEach(s13Urls, url =>
                {
                    news.Add(_s13Parser.Parse(url));
                });*/

                return news.ToList();



            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }


        private IEnumerable<string> GetUrlsFromRss()
        {
            var getDataFromRss = new ConcurrentBag<SyndicationItem>();
            Parallel.ForEach(Storage.Storage.rssFeeds, 
                   new ParallelOptions() { MaxDegreeOfParallelism = 3 },
                s =>
                {
                    var items = _rssReader.GetNewsFromFeed(s);
                    Parallel.ForEach(items, item => getDataFromRss.Add(item));
                });



            return getDataFromRss.Select(si=> si.Links.FirstOrDefault()?.Uri.AbsoluteUri).ToArray();


        }





    }


}
