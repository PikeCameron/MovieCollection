using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieCollectionContext _MovieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieCollectionContext context)
        {
            _logger = logger;
            _MovieContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // movie form page
        [HttpGet]
        public IActionResult MovieApp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieApp(MovieResponse ar)
        {
            _MovieContext.Add(ar);
            _MovieContext.SaveChanges();
            return View("Confirmation", ar);
        }

        // podcast page
        public IActionResult Podcast()
        {
            return View();
        }

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
