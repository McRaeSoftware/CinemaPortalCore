using CinemaPortalCore.Data;
using CinemaPortalCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPortalCore.Controllers
{
    public class MovieController : Controller
    {
        private readonly CinemaPortalCoreDbContext _database;

        public MovieController(CinemaPortalCoreDbContext database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> movieList = _database.Movies;
            return View(movieList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            _database.Movies.Add(movie);
            _database.SaveChanges();

            return View();
        }
    }
}
