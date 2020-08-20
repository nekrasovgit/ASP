using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DNekrasovDB.Models;
using Microsoft.EntityFrameworkCore;
using DNekrasovDB.Models.DB;
using DNekrasovDB.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace DNekrasovDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DBInitializer _dbInitializer;

        public HomeController(ILogger<HomeController> logger, DBInitializer dbInitializer)
        {
            _logger = logger;
            _dbInitializer = dbInitializer;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("bla bla bla");
            await _dbInitializer.Initialize();
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
