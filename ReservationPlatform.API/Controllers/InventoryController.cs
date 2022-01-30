using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OloPlatform.Models;
using OloPlatform.Services;

namespace OloPlatform.Controllers
{
    [ApiController]
    [Route("inventories")]
    public class InventoryController
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        
        [HttpPost]
        public async Task<InventoryResponseDto> Post([FromBody] InventoryRequestDto requestDto)
        {
            // Jimmy: Validating requestDto and return appropirate messages.
            var response = await _inventoryService.CreateInventory(requestDto);
            // Jimmy; Validating response and return appropirate messages.
            // aka 404 and so on.
            return response;
        }
    }
}