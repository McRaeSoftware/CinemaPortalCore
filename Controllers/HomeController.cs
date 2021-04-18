using CinemaPortalCore.Data;
using CinemaPortalCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPortalCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly CinemaPortalCoreDbContext _database;

        public HomeController(CinemaPortalCoreDbContext database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string username, string password)
        {
            try
            {
                using (_database)
                {
                    // The select is to save the data to a session later.
                    // for now im just using a logged in boolean
                    var result = _database.Employees.Where(e => e.Username == username && e.Password == password);//.Select(e => new { e.Employee_ID, e.Username, e.Jobrole}).ToHashSet();

                    if (result.Count() > 0)
                    {
                        Program.LoggedIn = true;
                        return RedirectToAction("Navigation");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult Logout()
        {
            Program.LoggedIn = false;
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Navigation()
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
