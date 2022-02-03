using System;
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
    public class IsInventoryRequestValidTests
    {
        [Test]
        public void GivenValidRequest_ShouldReturnTrue()
        {
            //Arrange
            var request = new InventoryRequestDto
            {
                RestaurantId = 1,
                TimeSlots = new[]
                {
                    new ReservationTimeSlotRequestDto()
                    {
                        TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                        ReservationCount = 1,
                        PartySize = 2,
                        ReservedDate = DateTime.Now.AddDays(2),
                    },
                    new ReservationTimeSlotRequestDto()
                    {
                        TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                        ReservationCount = 1,
                        PartySize = 2,
                        ReservedDate = DateTime.Now.AddDays(2),
                    }
                },
            };
            //Act
            var result = RequestValidator.IsInventoryRequestValid(request, out var error);
            //Assert
            result.ShouldBeTrue();
            error.ShouldBeNull();
        }

        [Test]
        [TestCaseSource(nameof(GetInvalidCases))]
        public void GivenInvalidRequest_ShouldReturnFalseWithError(InventoryRequestDto request, string message)
        {
            //Act
            var result = RequestValidator.IsInventoryRequestValid(request, out var error);

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
                var request = new InventoryRequestDto
                {
                    RestaurantId = -1,
                    TimeSlots = new[]
                    {
                        new ReservationTimeSlotRequestDto()
                        {
                            TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                            ReservationCount = 1,
                            PartySize = 2,
                            ReservedDate = DateTime.Now.AddDays(2),
                        },
                        new ReservationTimeSlotRequestDto()
                        {
                            TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                            ReservationCount = 1,
                            PartySize = 2,
                            ReservedDate = DateTime.Now.AddDays(2),
                        }
                    },
                };
                
                const string message = "Please provide a valid restaurant Id";

                return new TestCaseData(request, message)
                    .SetName(string.Concat("{m} - ", nameof(InValidRestaurantId)));
            }

            yield return InValidRestaurantId();

            TestCaseData InValidTimeSlots()
            {
                //Arrange
                var request = new InventoryRequestDto
                {
                    RestaurantId = 1,
                    TimeSlots = new[]
                    {
                        new ReservationTimeSlotRequestDto()
                        {
                            TimeSlotSection = (TimeSlotEnums) 1 ,
                            ReservationCount = 1,
                            PartySize = 2,
                            ReservedDate = DateTime.Now.AddDays(2),
                        },
                        new ReservationTimeSlotRequestDto()
                        {
                            TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                            ReservationCount = 1,
                            PartySize = 2,
                            ReservedDate = DateTime.Now.AddDays(2),
                        }
                    },
                };
                
                const string message = "One or more desired time slots are invalid";

                return new TestCaseData(request, message)
                    .SetName(string.Concat("{m} - ", nameof(InValidTimeSlots)));
            }

            yield return InValidTimeSlots();

            TestCaseData InValidReservedDate()
            {
                //Arrange
                var request = new InventoryRequestDto
                {
                    RestaurantId = 1,
                    TimeSlots = new[]
                    {
                        new ReservationTimeSlotRequestDto()
                        {
                            TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                            ReservationCount = 1,
                            PartySize = 2,
                            ReservedDate = DateTime.Now.AddDays(-1),
                        },
                        new ReservationTimeSlotRequestDto()
                        {
                            TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                            ReservationCount = 1,
                            PartySize = 2,
                            ReservedDate = DateTime.Now.AddDays(2),
                        }
                    },
                };

                const string message = "One or more desired reserved date are past due";

                return new TestCaseData(request, message)
                    .SetName(string.Concat("{m} - ", nameof(InValidReservedDate)));
            }

            yield return InValidReservedDate();

            TestCaseData InValidPartySize()
            {
                //Arrange
                var request = new InventoryRequestDto
                {
                    RestaurantId = 1,
                    TimeSlots = new[]
                    {
                        new ReservationTimeSlotRequestDto()
                        {
                            TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                            ReservationCount = 1,
                            PartySize = 0,
                            ReservedDate = DateTime.Now.AddDays(2),
                        },
                        new ReservationTimeSlotRequestDto()
                        {
                            TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                            ReservationCount = 1,
                            PartySize = 2,
                            ReservedDate = DateTime.Now.AddDays(2),
                        }
                    },
                };
                
                const string message = "One or more desired party size is less 1 person";

                return new TestCaseData(request, message)
                    .SetName(string.Concat("{m} - ", nameof(InValidPartySize)));
            }

            yield return InValidPartySize();

            TestCaseData InValidReservationCount()
            {
                //Arrange
                var request = new InventoryRequestDto
                {
                    RestaurantId = 1,
                    TimeSlots = new[]
                    {
                        new ReservationTimeSlotRequestDto()
                        {
                            TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                            ReservationCount = 0,
                            PartySize = 2,
                            ReservedDate = DateTime.Now.AddDays(2),
                        },
                        new ReservationTimeSlotRequestDto()
                        {
                            TimeSlotSection = TimeSlotEnums.Hour1TimeSlot1,
                            ReservationCount = 1,
                            PartySize = 2,
                            ReservedDate = DateTime.Now.AddDays(2),
                        }
                    },
                };

                const string message = "One or more reservation count is less than 1.";

                return new TestCaseData(request, message)
                    .SetName(string.Concat("{m} - ", nameof(InValidReservationCount)));
            }

            yield return InValidReservationCount();
        }
    }
}