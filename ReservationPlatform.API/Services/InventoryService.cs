using System.Collections.Generic;
using System.Transactions;
using OloPlatform.Models;
using OloPlatform.Repositories;

namespace OloPlatform.Services
{
    public class InventoryService: IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        
        public InventoryResponseDto CreateInventory(InventoryRequestDto requestDto)
        {

            var results = new List<int>();
            
            using (TransactionScope scope = new TransactionScope())
            {
                
            }

            return _inventoryRepository.CreateInventory(requestDto);
        }
    }
}