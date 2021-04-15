using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Video { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        [DisplayName("Release date")]
        public string ReleaseDate { get; set; }

        public string AgeRating { get; set; }
        public string RunTime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string StarRating { get; set; }
    }
}
