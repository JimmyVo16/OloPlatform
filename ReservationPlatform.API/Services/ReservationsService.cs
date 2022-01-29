using ReservationPlatform.API.Services;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class ReservationsService:  IReservationsService
    {
        private readonly IReservationsRepository _reservationsRepository;

        public ReservationsService(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }
        
        public ReservationResponse CreateReservation(ReservationRequestDto requestDto)
        {
            return _reservationsRepository.CreateReservation(requestDto);
        }
    }
}