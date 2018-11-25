using BookingAPI.Services.Data;
using BookingAPI.Services.Entity;
using BookingAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPI.Data.Helpers
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly BookingContext _ctx;

        public ReservationRepository()
        {
            _ctx = new BookingContext();
        }

        public int GetReservedSeats(DateTimeOffset date)
        {
            var min = date.Date;
            var max = date.Date.AddDays(1);

            return (from r in this._ctx.Reservations where min <= r.ReservationDate && r.ReservationDate < max select r.Qty)
            .DefaultIfEmpty(0)
            .Sum();

        }

        public async void Save(Reservation reservation)
        {
            _ctx.Reservations.Add(new Reservation
            {
                ReservationDate = reservation.ReservationDate,
                Name = reservation.Name,
                Email = reservation.Email,
                Qty = reservation.Qty,
                GuRecId=reservation.GuRecId
            });

            await _ctx.SaveChangesAsync();

        }
    }
}
