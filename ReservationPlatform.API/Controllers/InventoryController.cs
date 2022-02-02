using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OloPlatform.Controllers.Utilities;
using OloPlatform.Models;
using OloPlatform.Services;

namespace OloPlatform.Controllers
{
    [ApiController]
    [Route("inventories")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        
        [HttpPost]
        public async Task<ActionResult<InventoryResponseDto>> Post([FromBody] InventoryRequestDto requestDto)
        {
            if (!requestDto.TimeSlots.Any(i => RequestValidator.IsTimeSlotValid(i.TimeSlotSection)))
            {
                return UnprocessableEntity("One or more desired time slots are invalid");
            }
            
            var createdReservationIds = await _inventoryService.CreateReservations(requestDto);
            
            var reservationIds = createdReservationIds as int[] ?? createdReservationIds.ToArray();
            
            if (reservationIds.Any())
            {
                return Ok(new InventoryResponseDto
                {
                    CreatedReservationIds = reservationIds
                });
            }
            
            return this.Problem("Sorry we're unable to create your reservations", null, 500);
        }
    }
}