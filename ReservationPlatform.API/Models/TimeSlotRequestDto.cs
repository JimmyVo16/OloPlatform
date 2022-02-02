using OloPlatform.Enums;

namespace OloPlatform.Models
{
    public class TimeSlotRequestDto
    {
        public TimeSlotEnums TimeSlotSection { get; set; }
        public int ReservationCount { get; set; }
        public int PartySize { get; set; }
    }
}