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

        // Get employee details for update
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

        // Update movie details after post from updatemovie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _database.Movies.Update(movie);
                _database.SaveChanges();
            }
            return RedirectToAction("ManageMovie");
        }

        // Get movie details to delete
        public IActionResult DeleteMovie(int? id)
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

        // Delete movie details after post from delete page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMoviePOST(int Movie_ID)
        {
            var movie = _database.Movies.Find(Movie_ID);
            if (movie == null)
            {
                return NotFound();
            }

            _database.Movies.Remove(movie);
            _database.SaveChanges();

            return RedirectToAction("ManageMovie");
        }
    }
}
