using System.Threading.Tasks;
using OloPlatform.Models;

namespace OloPlatform.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IRepositoryUtilities _repositoryUtilities;
        
        private const string CreateReservationQuery = 
          @"DECLARE @MyTableVar TABLE
            (
                ReservationId int
            )
            INSERT INTO Reservations(PartySize, CustomerId, RestaurantId, TimeSlotSection)
            OUTPUT INSERTED.ReservationId INTO @MyTableVar  
            VALUES(@PartySize, NULL, @RestaurantId, @TimeSlotSection)

            Select ReservationId from @MyTableVar";
        
        public InventoryRepository(IRepositoryUtilities repositoryUtilities)
        {
            _repositoryUtilities = repositoryUtilities;
        }
        
        public async Task<CreatedReservationDto> CreateReservation(CreatedReservationRequestDto requestDto)
        {
            return await _repositoryUtilities.QuerySingleAsync<CreatedReservationDto>(CreateReservationQuery, requestDto);
        }
    }
}