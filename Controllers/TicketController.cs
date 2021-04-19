using CinemaPortalCore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPortalCore.Controllers
{
    public class TicketController : Controller
    {
        private readonly CinemaPortalCoreDbContext _database;

        public TicketController(CinemaPortalCoreDbContext database)
        {
            _database = database;
        }

        public string GenerateTicketCode()
        {
            DateTime now = new DateTime();
            string code;

            code = now.Year.ToString("X");
            code += now.Month.ToString("X");
            code += now.Day.ToString("X");
            code += now.Hour.ToString("X");
            code += now.Minute.ToString("X");
            code += now.Second.ToString("X");
            //code += customerID

            return code;
        }

        public IActionResult BookTicket()
        {
            return View();
        }
    }
}
