using System.Threading.Tasks;
using OloPlatform.Models;

namespace ReservationPlatform.API.Services
{
    public interface IReservationsService
    {
        public Task<BookReservationDto> BookReservation(ReservationRequestDto requestDto);
    }
}