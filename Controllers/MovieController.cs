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


        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMovie(Movie movie)
        {
            _database.Movies.Add(movie);
            _database.SaveChanges();

            return View();
        }

        public IActionResult ManageMovie()
        {
            IEnumerable<Movie> movieList = _database.Movies;
            return View(movieList);
        }

        // Get movie details for update
        public IActionResult UpdateMovie(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var movie = _database.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // Update movie details after post from updateMovie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _database.Movies.Update(movie);
                _database.SaveChanges();
            }
            return View();
        }
    }
}
