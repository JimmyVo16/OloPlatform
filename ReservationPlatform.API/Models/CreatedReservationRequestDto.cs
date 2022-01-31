namespace OloPlatform.Models
{
    public class CreatedReservationRequestDto
    {
        public string RestaurantId { get; set; }
        public int TimeSlotSection { get; set; }
        public int PartySize { get; set; }
    }
}