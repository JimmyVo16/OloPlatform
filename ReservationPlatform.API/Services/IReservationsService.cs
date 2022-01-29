using WebApplication1.Models;

namespace ReservationPlatform.API.Services
{
    public interface IReservationsService
    {
        public ReservationResponse CreateReservation(ReservationRequestDto requestDto);
    }
}