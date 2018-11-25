using BookingAPI.Interfaces;
using BookingAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Helpers
{
    public class ApiValidator : IApiValidator
    {
        private int capacity;

        public ApiValidator(int _capacity)
        {
            this.capacity = _capacity;
        }

        public bool CanAccept(int requestedSeats, int reservedSeats)
        {
            return requestedSeats + reservedSeats <= this.capacity;
        }

        public bool Validate(ReservationRendition rendition)
        {
            return DateTimeOffset.TryParse(rendition.ReservationDate, out DateTimeOffset dummy);
        }
    }
}
