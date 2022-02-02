using System;
using OloPlatform.Enums;

namespace OloPlatform.Models
{
    public class ReservationTimeSlotRequestDto
    {
        public TimeSlotEnums TimeSlotSection { get; set; }
        public int ReservationCount { get; set; }
        public int PartySize { get; set; }
        public DateTime ReservedDate { get; set; }
    }
}