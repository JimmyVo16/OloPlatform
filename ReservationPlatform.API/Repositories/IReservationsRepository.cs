using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IReservationsRepository
    {
        public ReservationResponse CreateReservation(ReservationRequestDto requestDto);
    }
}