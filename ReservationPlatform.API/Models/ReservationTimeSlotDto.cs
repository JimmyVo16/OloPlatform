namespace OloPlatform.Models
{
    public class ReservationTimeSlotDto
    {
        public string TimeSlot { get; set; }
        public int RestaurantId { get; set; }
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int PartySize { get; set; }
    }
}