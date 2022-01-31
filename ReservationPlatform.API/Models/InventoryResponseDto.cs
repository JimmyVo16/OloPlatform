using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace OloPlatform.Models
{
    public class InventoryResponseDto
    {
        public HttpStatusCode StatusCodes { get; set; }
        public IEnumerable<int> CreatedReservationIds { get; set; }
    }
}