using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieCollectionContext _MovieContext { get; set; }

        public HomeController(MovieCollectionContext context)
        {
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
            ViewBag.Categories = _MovieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieApp(MovieResponse ar)
        {
            if (ModelState.IsValid)
            {
                _MovieContext.Add(ar);
                _MovieContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = _MovieContext.Categories.ToList();

                return View(ar);
            }
           
        }

        // podcast page
        public IActionResult Podcast()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            var movies = _MovieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit( int Movieid)
        {
            ViewBag.Categories = _MovieContext.Categories.ToList();

            var movie = _MovieContext.Responses.Single(x => x.MovieId == Movieid);

            return View("MovieApp", movie);
        }

        [HttpPost]
        public IActionResult Edit (MovieResponse ed)
        {
            if (ModelState.IsValid)
            {
                _MovieContext.Update(ed);
                _MovieContext.SaveChanges();

                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _MovieContext.Categories.ToList();

                return View(ed);
            }
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _MovieContext.Responses.Single(x => x.MovieId == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse ar)
        {
            _MovieContext.Responses.Remove(ar);
            _MovieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
