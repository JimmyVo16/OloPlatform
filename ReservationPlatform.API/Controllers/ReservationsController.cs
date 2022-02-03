using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OloPlatform.Controllers.Utilities;
using ReservationPlatform.API.Services;
using OloPlatform.Models;

namespace OloPlatform.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsService _reservationsService;

        public ReservationsController(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }
   

        [HttpPatch]
        public async Task<ActionResult<ReservationResponseDto>> Post([FromBody] ReservationRequestDto requestDto)
        {
            if (!RequestValidator.IsReservationRequestValid(requestDto, out var error))
            {
                return error;
            }
            
            var response = await _reservationsService.BookReservation(requestDto);

            if (response.IsSuccess)
            {
                return Ok(new ReservationResponseDto
                {
                    BookedReservationId =  response.ReservationId
                });
            }

            return UnprocessableEntity("Sorry we're unable book your reservation");
        }
    }
}