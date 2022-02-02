using System;
using OloPlatform.Enums;

namespace OloPlatform.Controllers.Utilities
{
    public static class RequestValidator
    {
        public static bool IsTimeSlotValid(TimeSlotEnums timeslot)
        {
            return Enum.IsDefined(typeof(TimeSlotEnums), (int) timeslot);
        }
    }
}