using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using OloPlatform.Mappers;
using OloPlatform.Models;
using OloPlatform.Repositories;

namespace OloPlatform.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ILogger _logger;

        public InventoryService(IInventoryRepository inventoryRepository, ILogger logger)
        {
            _inventoryRepository = inventoryRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<CreatedReservationDto>> CreateReservations(InventoryRequestDto requestDto)
        {
            var createdReservationIds = new List<CreatedReservationDto>();

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                foreach (var timeSlot in requestDto.TimeSlots)
                {
                    for (var i = 0; i < timeSlot.ReservationCount; i++)
                    {

                        var request = timeSlot.ToCreatedReservationRequestDto();
                        request.RestaurantId = requestDto.RestaurantId;

                        var result = await _inventoryRepository.CreateReservation(request);

                        if (result.IsSuccess)
                        {
                            createdReservationIds.Add(result);
                        }
                        else
                        {
                            _logger.LogWarning("Create reservation for request.", request);
                        }
                        //TODO: Handle errors gratefully.
                    }
                }
                scope.Complete();
            }
            return createdReservationIds;
        }
    }
}