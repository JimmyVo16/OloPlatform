using System.Threading.Tasks;
using ReservationPlatform.API.Services;
using OloPlatform.Models;
using OloPlatform.Repositories;

namespace OloPlatform.Services
{
    public class ReservationsService:  IReservationsService
    {
        private readonly IReservationsRepository _reservationsRepository;

        public ReservationsService(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }
        
        public async Task<ReservationResponseDto> CreateReservation(ReservationRequestDto requestDto)
        {
            return await _reservationsRepository.CreateReservation(requestDto);
        }
    }
}