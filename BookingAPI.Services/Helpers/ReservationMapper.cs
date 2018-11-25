using BookingAPI.Services.Entity;
using BookingAPI.Services.Interfaces;
using BookingAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPI.Services.Helpers
{
    public class ReservationMapper : IReservationMapper
    {
        public Reservation Map(ReservationRendition rendition)
        {
            return new Reservation
            {
                ReservationDate=DateTimeOffset.Parse(rendition.ReservationDate),
                Name=rendition.Name,
                Email=rendition.Email,
                Qty=rendition.Qty,
                GuRecId=Guid.NewGuid().ToString()
            };
        }
    }
}
