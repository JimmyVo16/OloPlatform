using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OloPlatform.Enums;
using OloPlatform.Models;

namespace OloPlatform.Controllers.Utilities
{
    public static class RequestValidator
    {
        public static bool IsTimeSlotValid(TimeSlotEnums timeslot)
        {
            return Enum.IsDefined(typeof(TimeSlotEnums), (int) timeslot);
        }

        public static  bool IsReservationRequestValid(ReservationRequestDto requestDto, out ActionResult result)
        {
            if (requestDto.RestaurantId <= 0)
            {
                result = new BadRequestObjectResult("Please provide a valid restaurant Id");
                return false;
            }
            
            if (!RequestValidator.IsTimeSlotValid(requestDto.CustomerRequestedTimeSlot))
            {
                result = new BadRequestObjectResult("Sorry your time slot was invalid");
                return false;
            }

            if (requestDto.ReservedDate < DateTime.Today)
            {
                result = new BadRequestObjectResult("Sorry the reserved date is past due");
                return false;
            }
            
            if (!(new EmailAddressAttribute().IsValid(requestDto.EmailAddress)))
            {
                result = new BadRequestObjectResult("Please provide a valid email address");
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(requestDto.CustomerName))
            {
                result = new BadRequestObjectResult("Please provide a customer name");
                return false;
            }
            
            result = null;
            return true;
        }   
        
        public static bool IsInventoryRequestValid(InventoryRequestDto requestDto, out ActionResult result)
        {
            if (requestDto.RestaurantId <= 0)
            {
                result = new BadRequestObjectResult("Please provide a valid restaurant Id");
                return false;
            }

            if (!requestDto.TimeSlots.All(i => RequestValidator.IsTimeSlotValid(i.TimeSlotSection)))
            {
                result = new BadRequestObjectResult("One or more desired time slots are invalid");
                return false;
            }

            if (requestDto.TimeSlots.Any(i => i.ReservedDate < DateTime.Today))
            {
                result = new BadRequestObjectResult("One or more desired reserved date are past due");
                return false;
            }
            
            if (requestDto.TimeSlots.Any(i => i.PartySize <= 0))
            {
                result = new BadRequestObjectResult("One or more desired party size is less 1 person");
                return false;
            }
            
            if (requestDto.TimeSlots.Any(i => i.ReservationCount <= 0))
            {
                result = new BadRequestObjectResult("One or more reservation count is less than 1.");
                return false;
            }
            
            result = null;
            return true;
        }
    }
}