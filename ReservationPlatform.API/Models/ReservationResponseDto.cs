using System.Net;
using Microsoft.AspNetCore.Http;

namespace OloPlatform.Models
{
    public class ReservationResponseDto
    {
        public HttpStatusCode StatusCodes { get; set; }

        // Jimmy
        public string Result { get; set; }
    }
}