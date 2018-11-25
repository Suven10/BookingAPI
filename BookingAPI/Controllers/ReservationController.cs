using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookingAPI.Data.Helpers;
using BookingAPI.Helpers;
using BookingAPI.Services.Interfaces;
using BookingAPI.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        ApiValidator _apiValidator;
        IReservationRepository _repository;
        IReservationMapper _mapper;

        public IActionResult Index()
        {
            return Ok();
        }

        public ReservationController(ApiValidator apiValidator, IReservationMapper mapper, IReservationRepository repository)
        {
            _apiValidator =apiValidator;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReservationRendition rendition)
        {
            if (!this._apiValidator.Validate(rendition))
                return this.BadRequest("Invalid date.");

            var r = this._mapper.Map(rendition);
            var reservedSeats = this._repository.GetReservedSeats(r.ReservationDate);
            if (!this._apiValidator.CanAccept(rendition.Qty, reservedSeats))
                return this.NoContent();
            this._repository.Save(r);
            return this.Ok();
        }
    }
}