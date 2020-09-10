using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.ServiceModel.Syndication;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using DNekrasovDB.Data.NewsService;
using DNekrasovDB.Data.UnitOfWork;
using DNekrasovDB.Models.DB;
using System.Collections.Generic;

namespace DNekrasovDB.Controllers
{
    public class NewsController : Controller
    {
        
        private readonly INewsService _newsService;
        private readonly ILogger<NewsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        

        public NewsController(ILogger<NewsController> logger, INewsService newsService)
        {
  
            _newsService = newsService;
            _logger = logger;
            _newsService = newsService;

        }

        /*public IActionResult Index()
        {
            var newsModel = _goodNewsContext.News.ToList();
            
            return View(newsModel);
        }

        public IActionResult Details(Guid id)
        {
            var newsModel = _goodNewsContext.News.FirstOrDefault(news => news.Id.Equals(id));

            return View(newsModel);
        }*/

        public IActionResult List()
        {
            try
            {

                _unitOfWork.NewsRepository.GetAllAsync();

                var mynews = new ConcurrentBag<SyndicationItem>();

                _newsService.GetDataFromRssInsertIntoDB();

                _unitOfWork.SaveChangesAsync();

                return View(mynews.OrderByDescending(item => item.PublishDate));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

       
    }

   
}