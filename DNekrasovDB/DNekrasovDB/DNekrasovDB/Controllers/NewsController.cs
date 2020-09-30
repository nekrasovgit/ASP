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
using System.Threading.Tasks;

namespace DNekrasovDB.Controllers
{
    public class NewsController : Controller
    {
        
        private readonly INewsService _newsService;
        private readonly ILogger<NewsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        

        public NewsController(ILogger<NewsController> logger, INewsService newsService, IUnitOfWork unitOfWork)
        {
  
            _newsService = newsService;
            _logger = logger;
            _unitOfWork = unitOfWork;

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
        //todo make it post & use ajax
        public IActionResult RefreshNews()
        {
            //_newsService.Insert....
            _newsService.InsertNewsFromRssToDb();
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List()
        {
            try
            {

                var data = await _unitOfWork.NewsRepository.GetAllAsync();

                return View(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

       
    }

   
}