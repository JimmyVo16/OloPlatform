using System.Collections.Generic;

namespace OloPlatform.Models
{
    public class InventoryResponseDto
    {
        public IEnumerable<int> CreatedReservations { get; set; }
    }
}