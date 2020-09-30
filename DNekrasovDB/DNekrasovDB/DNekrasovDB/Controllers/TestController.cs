using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNekrasovDB.Data.Repository;
using DNekrasovDB.Data.UnitOfWork;
using DNekrasovDB.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace DNekrasovDB.Controllers
{
    public class TestController : Controller
    {
        
        private readonly IUnitOfWork _unitofwork;

        public TestController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        
        public async Task<IActionResult> Index()
        {
            
            /*await _unitofwork.MagazineRepository
                .AddAsync(new Magazine() { Id = Guid.NewGuid(), Name = "Onliner", RssUrl = @"onliner.by"});
            await _unitofwork.SaveChangesAsync();
            */
            return View();
        }
    }
}