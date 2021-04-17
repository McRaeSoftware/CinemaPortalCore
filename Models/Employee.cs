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
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Jobrole { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
