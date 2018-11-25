using BookingAPI.Services.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPI.Services.Interfaces
{
    public interface IReservationRepository
    {
        int GetReservedSeats(DateTimeOffset date);
        void Save(Reservation reservation);
    }
}
