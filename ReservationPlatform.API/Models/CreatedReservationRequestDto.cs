using OloPlatform.Enums;

namespace OloPlatform.Models
{
    public class CreatedReservationRequestDto
    {
        public int RestaurantId { get; set; }
        public TimeSlotEnums TimeSlotSection { get; set; }
        public int PartySize { get; set; }
    }
}