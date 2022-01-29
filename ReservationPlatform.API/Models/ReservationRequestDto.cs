using System;

namespace WebApplication1.Models
{
    public class ReservationRequestDto
    {
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public int PartySize { get; set; }
        // Jimmy verify the input with Olo
        // For the date and time
        // Also the restaurant Id.
        // Q: Ask if you're designing this for just one resutatnar or multiple. 
        // most likey it's for multiple
        public DateTime Date { get; set; }
    }
}