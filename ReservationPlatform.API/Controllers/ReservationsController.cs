using Microsoft.AspNetCore.Mvc;
using ReservationPlatform.API.Services;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("v1/Reservations")]
    public class ReservationsController
    {
        private readonly IReservationsService _reservationsService;

        public ReservationsController(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }


        [HttpPost]
        public ActionResult<ReservationResponse> Post([FromBody] ReservationRequestDto requestDto)
        {
            // Jimmy: Validating requestDto and return appropirate messages.
            var response = _reservationsService.CreateReservation(requestDto);
            // Jimmy; Validating response and return appropirate messages.
            // aka 404 and so on.
            return response;
        }
    }
}