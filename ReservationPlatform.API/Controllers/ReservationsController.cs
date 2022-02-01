using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservationPlatform.API.Services;
using OloPlatform.Models;
using OloPlatform.Services;

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

        // Jimmy check if this is PUT or PATCH
        [HttpPatch]
        public async Task<ActionResult<ReservationResponseDto>> Post([FromBody] ReservationRequestDto requestDto)
        {
            // Jimmy: Validating requestDto and return appropirate messages.
            var response = await _reservationsService.BookReservation(requestDto);
            // Jimmy; Validating response and return appropirate messages.
            
            
            if (response.IsSuccess)
            {
                return this.Ok(response);
            }
            
            // aka 404 and so on.
            return this.Problem("Sorry we're unable book your reservation", null, 500);
        }
    }
}