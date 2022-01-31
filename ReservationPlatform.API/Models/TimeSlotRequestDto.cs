namespace OloPlatform.Models
{
    public class TimeSlotRequestDto
    {
        // Jimmy: Explain to interviewers why it's a string 
        public int TimeSlotSection { get; set; }
        public int ReservationCount { get; set; }
        public int PartySize { get; set; }
    }
}