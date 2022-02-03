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
        
        [HttpPost]
        public async Task<ActionResult<InventoryResponseDto>> Post([FromBody] InventoryRequestDto requestDto)
        {
            if (!RequestValidator.IsInventoryRequestValid(requestDto, out var error))
            {
                return error;
            }
            
            var createdReservations = (await _inventoryService.CreateReservations(requestDto)).ToArray();
            
            if (createdReservations.Any())
            {
                return Ok(new InventoryResponseDto
                {
                    CreatedReservationIds = createdReservations.Select(i => i.ReservationId)
                });
            }
            
            return this.Problem("Sorry we're unable to create your reservations", null, 409);
        }

    }
}