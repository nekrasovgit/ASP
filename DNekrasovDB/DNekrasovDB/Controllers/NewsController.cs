using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNekrasovDB.Models.DB;
using Microsoft.AspNetCore.Mvc;
using DNekrasovDB.ModelView;

namespace DNekrasovDB.Controllers
{
    public class NewsController : Controller
    {
        private readonly GoodNewsContext _goodNewsContext;

        public NewsController(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }

        public IActionResult Index()
        {
            var newsModel = _goodNewsContext.News.ToList();
            
            return View(newsModel);
        }

        public IActionResult Details(Guid id)
        {
            var newsModel = _goodNewsContext.News.FirstOrDefault(news => news.Id.Equals(id));

            return View(newsModel);
        }

        public IActionResult Create()
        {
            

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsViewModel newsModel)
        {

            try
            {
                var news = new News()
                {
                    Id = Guid.NewGuid(),
                    Name = newsModel.Name
                };
                await _goodNewsContext.AddAsync(news);
                await _goodNewsContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }

        public IActionResult Edit(Guid id)
        {
            var news = _goodNewsContext.News.FirstOrDefault(news => news.Id.Equals(id));
            if (news!= null)
            {
                var newsModel = new EditNewsViewModel()
                {
                    Id = news.Id,
                    Name = news.Name
                };
                return View(newsModel);
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Edit(EditNewsViewModel newsModel)
        {
            try
            {
                var news = new News()
                {
                    Id = newsModel.Id,
                    Name = newsModel.Name
                };
                _goodNewsContext.Update(news);
                await _goodNewsContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }
    }
}