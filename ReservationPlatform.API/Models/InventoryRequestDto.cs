using System.Collections;
using System.Collections.Generic;

namespace OloPlatform.Models
{
    public class InventoryRequestDto
    {
        public string RestaurantId { get; set; }
        public IEnumerable<TimeSlotRequestDto> TimeSlots { get; set; }
    }
}