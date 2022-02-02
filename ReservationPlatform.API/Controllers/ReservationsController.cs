using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OloPlatform.Controllers.Utilities;
using OloPlatform.Enums;
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
            if (!RequestValidator.IsTimeSlotValid(requestDto.CustomerRequestedTimeSlot))
            {
                return UnprocessableEntity("Sorry your time slot was invalid");
            }
            
            var response = await _reservationsService.BookReservation(requestDto);

            if (response.IsSuccess)
            {
                return Ok(new ReservationResponseDto
                {
                    BookedReservationId =  response.ReservationId
                });
            }

            return Problem("Sorry we're unable book your reservation", null, 500);
        }
    }
}