using System.Net;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Models
{
    public class ReservationResponse
    {
        public HttpStatusCode StatusCodes { get; set; }

        // Jimmy
        public string Result { get; set; }
    }
}