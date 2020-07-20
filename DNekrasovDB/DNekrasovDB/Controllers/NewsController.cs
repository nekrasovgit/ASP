using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNekrasovDB.Models.DB;
using DNekrasovDB.ModelView.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DNekrasovDB.Controllers
{
    public class NewsController : Controller
    {
        private GoodNewsContext goodNewsContext;
        private List<News> allnews;
        

        public NewsController(GoodNewsContext gNC)
        {
            goodNewsContext = gNC;
            allnews = new List<News>()
            {
                 new News(){},
                 new News(){},
                 new News(){},
                 new News(){}
            };
        }

        public IActionResult Index()
        {
            var newsVMCollection = allnews.Select(news => new NewsViewModel()
            {
                Name = news.Name,
                Body = news.Body
            }).ToList();
            return View(newsVMCollection);
        }

        


    }
}