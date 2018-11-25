using BookingAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Interfaces
{
    public interface IApiValidator
    {
        bool Validate(ReservationRendition rendition);
        bool CanAccept(int requestedSeats, int reservedSeats);
    }
}
