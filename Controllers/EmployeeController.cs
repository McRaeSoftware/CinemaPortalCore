using CinemaPortalCore.Data;
using CinemaPortalCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPortalCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CinemaPortalCoreDbContext _database;

        public EmployeeController(CinemaPortalCoreDbContext database)
        {
            _database = database;
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        public IActionResult ManageEmployee()
        {
            IEnumerable<Employee> empList = _database.Employees;
            return View(empList);
        }
    }
}
