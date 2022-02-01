using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace OloPlatform.Models
{
    public class InventoryResponseDto
    {
        public IEnumerable<int> CreatedReservationIds { get; set; }
    }
}