using BookingAPI.Services.Entity;
using BookingAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPI.Services.Interfaces
{
    public interface IReservationMapper
    {
        Reservation Map(ReservationRendition rendition);
    }
}
