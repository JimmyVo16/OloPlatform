namespace OloPlatform.Models
{
    public class CreatedReservationRequestDto
    {
        public int RestaurantId { get; set; }
        public int TimeSlotSection { get; set; }
        public int PartySize { get; set; }
    }
}