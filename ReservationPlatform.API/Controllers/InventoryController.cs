using System;
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
        
        private bool IsValid(InventoryRequestDto requestDto, out ActionResult result)
        {
            if (!requestDto.TimeSlots.Any(i => RequestValidator.IsTimeSlotValid(i.TimeSlotSection)))
            {
                result = UnprocessableEntity("One or more desired time slots are invalid");
                return false;
            }

            if (requestDto.TimeSlots.Any(i => i.ReservedDate < DateTime.Today))
            {
                result = UnprocessableEntity("One or more desired reserved date are past due");
                return false;
            }
            
            result = null;
            return true;
        }   
        
        [HttpPost]
        public async Task<ActionResult<InventoryResponseDto>> Post([FromBody] InventoryRequestDto requestDto)
        {
            if (IsValid(requestDto, out var error))
            {
                return error;
            }
            
            var createdReservations = (await _inventoryService.CreateReservations(requestDto)).ToArray();
            
            if (createdReservations.Any())
            {
                return Ok(new InventoryResponseDto
                {
                    CreatedReservations = createdReservations.Select(i => i.ReservationId)
                });
            }
            
            return this.Problem("Sorry we're unable to create your reservations", null, 409);
        }
    }
}