using System;
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
        
        private bool IsValid(ReservationRequestDto requestDto, out ActionResult result)
        {
            if (!RequestValidator.IsTimeSlotValid(requestDto.CustomerRequestedTimeSlot))
            {
                result = UnprocessableEntity("Sorry your time slot was invalid");
                return false;
            }

            if (requestDto.ReservedDate < DateTime.Today)
            {
                result = UnprocessableEntity("Sorry the reserved date is past due");
                return false;
            }
            
            result = null;
            return true;
        }   

        [HttpPatch]
        public async Task<ActionResult<ReservationResponseDto>> Post([FromBody] ReservationRequestDto requestDto)
        {
            if (!IsValid(requestDto, out var error))
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