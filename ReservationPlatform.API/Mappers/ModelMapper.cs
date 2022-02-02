using OloPlatform.Models;

namespace OloPlatform.Mappers
{
    public static class ModelMapper
    {
        public static CreatedReservationRequestDto ToCreatedReservationRequestDto(this ReservationTimeSlotRequestDto source)
        {
            return new CreatedReservationRequestDto
            {
                TimeSlotSection = source.TimeSlotSection,
                PartySize = source.PartySize,
                ReservedDate = source.ReservedDate
            };
        }

    }
}