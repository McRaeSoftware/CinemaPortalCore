using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPortalCore.Models
{
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Jobrole { get; set; }

        public string Password { get; set; }
    }
}
