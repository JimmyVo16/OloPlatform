using System.Collections.Generic;

namespace OloPlatform.Models
{
    public class InventoryRequestDto
    {
        public int RestaurantId { get; set; }
        public IEnumerable<ReservationTimeSlotRequestDto> TimeSlots { get; set; }
    }
}