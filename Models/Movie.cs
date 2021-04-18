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

        [Required]
        public string Title { get; set; }

        // made this field nullable as there will be no mp4 files uploaded
        public string Video { get; set; }

        // made this field nullable as there will be no images uploaded
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Release date")]
        public string ReleaseDate { get; set; }

        [Required]
        [DisplayName("Age rating")]
        public string AgeRating { get; set; }

        [Required]
        [DisplayName("Run time")]
        public string RunTime { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Actors { get; set; }

        [Required]
        [Range(0, 5)]
        [DisplayName("Star rating")]
        public string StarRating { get; set; }
    }
}
