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
        public IActionResult CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _database.Employees.Add(employee);
                _database.SaveChanges();
            }
            return View();
        }

        // Get employee details to delete
        public IActionResult DeleteEmployee(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var employee = _database.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // Delete employee details after post from delete page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployeePOST(int Employee_ID)
        {
            var employee = _database.Employees.Find(Employee_ID);

            if(employee == null)
            {
                return NotFound();
            }

            _database.Employees.Remove(employee);
            _database.SaveChanges();

            return RedirectToAction("ManageEmployee");
        }


        public IActionResult ManageEmployee()
        {
            IEnumerable<Employee> employeeList = _database.Employees;
            return View(employeeList);
        }
    }
}
