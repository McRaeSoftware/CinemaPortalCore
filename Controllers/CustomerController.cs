using CinemaPortalCore.Data;
using CinemaPortalCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPortalCore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CinemaPortalCoreDbContext _database;

        public CustomerController(CinemaPortalCoreDbContext database)
        {
            _database = database;
        }

        public IActionResult ManageCustomer()
        {
            IEnumerable<Customer> customerList = _database.Customers;
            return View(customerList);
        }

        // Create Employee View
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _database.Customers.Add(customer);
                _database.SaveChanges();
            }
            return View();
        }
    }
}
