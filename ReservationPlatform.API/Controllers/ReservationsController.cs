using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservationPlatform.API.Services;
using OloPlatform.Models;
using OloPlatform.Services;

namespace OloPlatform.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ReservationsController
    {
        private readonly IReservationsService _reservationsService;

        public ReservationsController(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }


        [HttpPost]
        public async Task<ReservationResponseDto> Post([FromBody] ReservationRequestDto requestDto)
        {
            // Jimmy: Validating requestDto and return appropirate messages.
            var response = await _reservationsService.BookReservation(requestDto);
            // Jimmy; Validating response and return appropirate messages.
            // aka 404 and so on.
            return response;
        }
    }
}