using System.Threading.Tasks;
using OloPlatform.Models;

namespace OloPlatform.Repositories
{
    public interface IReservationsRepository
    {
        public Task<BookReservationDto> BookReservation(
            ReservationRequestDto requestDto, 
            int customerId,
            int timeSlotSection);
        
        public Task<int> GetCustomerId(ReservationRequestDto requestDto);
    }
}