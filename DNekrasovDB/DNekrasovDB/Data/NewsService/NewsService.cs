using System;
using System.Collections.Concurrent;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using DNekrasovDB.Data.UnitOfWork;
using DNekrasovDB.Data.NewsParser;
using DNekrasovDB.Data.RssReader;
using Microsoft.Extensions.Logging;

namespace DNekrasovDB.Data.NewsService
{
    public class NewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRssReader _rssReader;
        private readonly INewsParser _newsParser;
        private readonly ILogger _logger;

        public NewsService(IUnitOfWork unitOfWork, IRssReader rssReader, INewsParser newsparser)
        {
            _unitOfWork = unitOfWork;
            _rssReader = rssReader;
            _newsParser = newsparser;

        }

        public void GetDataFromRssInsertIntoDB()
        {
            try
            {
                var rssData = GetDataFromRss();

                foreach (var syndicationItem in rssData)
                {
                    _newsParser.Parse(syndicationItem.Links.FirstOrDefault()?.Uri.AbsoluteUri);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

            }
        }


        private SyndicationItem[] GetDataFromRss()
        {
            var getDataFromRss = new ConcurrentBag<SyndicationItem>();
            Parallel.ForEach(Storage.Storage.rssFeeds, new ParallelOptions() { MaxDegreeOfParallelism = 3 },
                s =>
                {
                    var items = _rssReader.GetNewsFromFeed(s);
                    Parallel.ForEach(items, item => getDataFromRss.Add(item));
                });
            return getDataFromRss.ToArray();

            
        }
    }


}
