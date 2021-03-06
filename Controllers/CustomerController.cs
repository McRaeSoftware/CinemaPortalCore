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

        // Create Customer View
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

        public IActionResult UpdateCustomer(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var customer = _database.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _database.Customers.Update(customer);
                _database.SaveChanges();
            }
            return RedirectToAction("ManageCustomer");
        }

        // Get customer details before Deleting
        public IActionResult DeleteCustomer(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var customer = _database.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // Delete customer details after post from delete page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomerPOST(int Customer_ID)
        {
            var customer = _database.Customers.Find(Customer_ID);

            if (customer == null)
            {
                return NotFound();
            }

            _database.Customers.Remove(customer);
            _database.SaveChanges();

            return RedirectToAction("ManageCustomer");
        }
    }
}
