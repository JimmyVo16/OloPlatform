using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using OloPlatform.Models;
using OloPlatform.Repositories;

namespace OloPlatform.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<InventoryResponseDto> CreateInventory(InventoryRequestDto requestDto)
        {
            var results = new List<int>();

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                foreach (var timeSlot in requestDto.TimeSlots)
                {
                    for (int i = 0; i < timeSlot.ReservationCount; i++)
                    {
                        //Jimmy: case reservation already exist. 
                        // case: the customer created 3 at first then another 5.
                        await _inventoryRepository.CreateReservationTimeSlot(requestDto);
                    }
                    

                }

                scope.Complete();
            }

            return await _inventoryRepository.CreateReservationTimeSlot(requestDto);
        }
    }
}