namespace OloPlatform.Models
{
    public class ReservationTimeSlotDto
    {
        public string TimeSlot { get; set; }
        public string RestaurantId { get; set; }
        public string ReservationId { get; set; }
        public string CustomerId { get; set; }
        public int PartySize { get; set; }
    }
}