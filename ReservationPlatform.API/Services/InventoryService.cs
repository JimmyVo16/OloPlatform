using System;
using System.Collections.Generic;
using System.Net;
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
            var createdReservationIds = new List<int>();

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                foreach (var timeSlot in requestDto.TimeSlots)
                {
                    for (int i = 0; i < timeSlot.ReservationCount; i++)
                    {
                        var request = new CreatedReservationRequestDto
                        {
                            RestaurantId = requestDto.RestaurantId,
                            TimeSlotSection = timeSlot.TimeSlotSection,
                            PartySize = timeSlot.PartySize
                        };

                        var result = await _inventoryRepository.CreateReservationTimeSlot(request);
                   
                        createdReservationIds.Add(result.ReservationId);
                    }
                }
                
                scope.Complete();
            }

            return new InventoryResponseDto
            {
                StatusCodes = HttpStatusCode.OK,
                CreatedReservationIds =  createdReservationIds
            };
        }
    }
}