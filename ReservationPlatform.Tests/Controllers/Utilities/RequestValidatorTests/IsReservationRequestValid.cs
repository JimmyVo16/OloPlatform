using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OloPlatform.Controllers.Utilities;
using OloPlatform.Enums;
using OloPlatform.Models;
using Shouldly;

namespace ReservationPlatform.Tests.Controllers.Utilities.RequestValidatorTests
{
    [TestFixture]
    public class IsReservationRequestValid
    {
        [Test]
        public void GivenValidRequest_ShouldReturnTrue()
        {
            //Arrange
            var request = new ReservationRequestDto
            {
                RestaurantId = 1,
                CustomerRequestedTimeSlot = TimeSlotEnums.Hour1TimeSlot1,
                ReservedDate = DateTime.Now,
                EmailAddress = "Customer@olo.com",
                CustomerName = "CustomerVo"
            };
            //Act
            var result = RequestValidator.IsReservationRequestValid(request, out var error);
            //Assert
            result.ShouldBeTrue();
            error.ShouldBeNull();
        }

        [Test]
        [TestCaseSource(nameof(GetInvalidCases))]
        public void GivenInvalidRequest_ShouldReturnFalseWithError(ReservationRequestDto request, string message)
        {
            //Act
            var result = RequestValidator.IsReservationRequestValid(request, out var error);
            
            //Assert
            
            result.ShouldBeFalse();
            error.ShouldBeOfType<BadRequestObjectResult>();
            ((BadRequestObjectResult) error).Value.ShouldBe(message);
        }
        
        private static IEnumerable<TestCaseData> GetInvalidCases()
        {
            TestCaseData InValidRestaurantId()
            {
                //Arrange
                var request = new ReservationRequestDto
                {
                    RestaurantId = -1,
                    CustomerRequestedTimeSlot = TimeSlotEnums.Hour1TimeSlot1,
                    ReservedDate = DateTime.Now,
                    EmailAddress = "Customer@olo.com",
                    CustomerName = "CustomerVo"
                };
                const string message = "Please provide a valid restaurant Id";
                
                return new TestCaseData(request, message)
                    .SetName(string.Concat("{m} - ", nameof(InValidRestaurantId)));
            }
            yield return InValidRestaurantId(); 
            
            TestCaseData InValidTimeSlots()
            {
                //Arrange
                var request = new ReservationRequestDto
                {
                    RestaurantId = 1,
                    CustomerRequestedTimeSlot = (TimeSlotEnums) 119,
                    ReservedDate = DateTime.Now,
                    EmailAddress = "Customer@olo.com",
                    CustomerName = "CustomerVo"
                };
                const string message = "Sorry your time slot was invalid";
                
                return new TestCaseData(request, message)
                    .SetName(string.Concat("{m} - ", nameof(InValidTimeSlots)));
            }
            yield return InValidTimeSlots(); 
            
            TestCaseData InValidReservedDate()
            {
                //Arrange
                var request = new ReservationRequestDto
                {
                    RestaurantId = 1,
                    CustomerRequestedTimeSlot = TimeSlotEnums.Hour1TimeSlot1,
                    ReservedDate = DateTime.Now.AddDays(-1),
                    EmailAddress = "Customer@olo.com",
                    CustomerName = "CustomerVo"
                };
                
                const string message = "Sorry the reserved date is past due";
                
                return new TestCaseData(request, message)
                    .SetName(string.Concat("{m} - ", nameof(InValidReservedDate)));
            }
            yield return InValidReservedDate(); 
            
            TestCaseData InValidEmailAddress()
            {
                //Arrange
                var request = new ReservationRequestDto
                {
                    RestaurantId = 1,
                    CustomerRequestedTimeSlot = TimeSlotEnums.Hour1TimeSlot1,
                    ReservedDate = DateTime.Now,
                    EmailAddress = "Customerolo.com",
                    CustomerName = "CustomerVo"
                };
                
                const string message = "Please provide a valid email address";
                
                return new TestCaseData(request, message)
                    .SetName(string.Concat("{m} - ", nameof(InValidEmailAddress)));
            }
            yield return InValidEmailAddress(); 
            
            TestCaseData InValidCustomerName()
            {
                //Arrange
                var request = new ReservationRequestDto
                {
                    RestaurantId = 1,
                    CustomerRequestedTimeSlot = TimeSlotEnums.Hour1TimeSlot1,
                    ReservedDate = DateTime.Now,
                    EmailAddress = "Customer@olo.com",
                    CustomerName = null
                };
                
                const string message = "Please provide a customer name";
                
                return new TestCaseData(request, message)
                    .SetName(string.Concat("{m} - ", nameof(InValidCustomerName)));
            }
            yield return InValidCustomerName(); 
        }
    }
}