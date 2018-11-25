using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Services.Entity
{
    public class Reservation
    {
        [Required]
        public DateTimeOffset ReservationDate { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Qty { get; set; }
        [Key]
        public string GuRecId { get; set; }
    }
}
