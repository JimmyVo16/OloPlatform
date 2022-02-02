using System.Threading.Tasks;
using System.Transactions;
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
        
        public async Task<BookReservationDto> BookReservation(ReservationRequestDto requestDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var customerId = await _reservationsRepository.GetCustomerId(requestDto);
                
                var result = await _reservationsRepository.BookReservation(
                    requestDto, 
                    customerId);
                
                scope.Complete();
                return result;
            }
        }
    }
}