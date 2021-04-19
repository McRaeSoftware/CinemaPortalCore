using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPortalCore.Models
{
    public class Ticket
    {
        [Key]
        public int Ticket_ID { get; set; }

        [Required]
        [DisplayName("Code")]
        public string TicketCode { get; set; }

        [Required]
        [DisplayName("Seating")]
        public string SeatingType { get; set; }

        [Required]
        public string MovieTitle { get; set; }
    }
}
