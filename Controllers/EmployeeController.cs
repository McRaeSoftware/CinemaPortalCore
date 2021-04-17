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

        // Get employee details for update
        public IActionResult UpdateEmployee(int? id)
        {
            if (id == null || id == 0)
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

        // Update employee details after post from updateEmployee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _database.Employees.Update(employee);
                _database.SaveChanges();
            }
            return View();
        }

        // Get employee details to delete
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null || id == 0)
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
            if (employee == null)
            {
                return NotFound();
            }

            _database.Employees.Remove(employee);
            _database.SaveChanges();

            return RedirectToAction("ManageEmployee");
        }

        public IActionResult PromoteEmployee(int id)
        {
            string newJobrole;
            var employee = _database.Employees.Find(id);

            if (employee.Jobrole == "employee")
            {
                newJobrole = "supervisor";
            }
            else
            {
                newJobrole = "manager";
            }

            employee.Jobrole = newJobrole;
            _database.SaveChanges();

            return RedirectToAction("ManageEmployee");
        }

        public IActionResult DemoteEmployee(int id)
        {
            string newJobrole;
            var employee = _database.Employees.Find(id);

            if (employee.Jobrole == "manager")
            {
                newJobrole = "supervisor";
            }
            else
            {
                newJobrole = "employee";
            }

            employee.Jobrole = newJobrole;
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
