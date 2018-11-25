using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Services.Models
{
    public class ReservationRendition
    {
        public string ReservationDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Qty { get; set; }
    }
}
