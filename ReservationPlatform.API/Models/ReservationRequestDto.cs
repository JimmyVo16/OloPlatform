using System;
using OloPlatform.Enums;

namespace OloPlatform.Models
{
    public class ReservationRequestDto
    {
        public string CustomerName { get; set; }
        public int RestaurantId { get; set; }
        public string EmailAddress { get; set; }
        public int PartySize { get; set; }
        
        public DateTime ReservedDate { get; set; }
        public TimeSlotEnums CustomerRequestedTimeSlot { get; set; }
        
    }
}