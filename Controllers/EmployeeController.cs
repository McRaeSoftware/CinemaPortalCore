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

        // Create Employee View
        public IActionResult CreateEmployee()
        {
            return View();
        }

        // Create employee form action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmployee(Employee emp)
        {
            _database.Employees.Add(emp);
            _database.SaveChanges();

            return View();
        }

        public IActionResult ManageEmployee()
        {
            IEnumerable<Employee> empList = _database.Employees;
            return View(empList);
        }
    }
}
