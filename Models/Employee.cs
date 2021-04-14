using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPortalCore.Models
{
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }
        public string Username { get; set; }
        public string Jobrole { get; set; }
    }
}
