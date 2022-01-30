using System.Threading.Tasks;
using OloPlatform.Models;

namespace OloPlatform.Repositories
{
    public interface IReservationsRepository
    {
        public Task<ReservationResponseDto> CreateReservation(ReservationRequestDto requestDto);
    }
}