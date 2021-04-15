using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPortalCore.Models
{
    public class Movie
    {
        [Key]
        public int Movie_ID { get; set; }

        public string Title { get; set; }
    }
}
