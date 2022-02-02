using System.Collections.Generic;

namespace OloPlatform.Models
{
    public class InventoryResponseDto
    {
        public IEnumerable<int> CreatedReservationIds { get; set; }
    }
}