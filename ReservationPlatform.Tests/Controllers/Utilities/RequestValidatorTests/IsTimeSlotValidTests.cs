using NUnit.Framework;
using OloPlatform.Controllers.Utilities;
using OloPlatform.Enums;
using Shouldly;

namespace ReservationPlatform.Tests.Controllers.Utilities.RequestValidatorTests
{
    [TestFixture]
    public class IsTimeSlotValidTests
    {
        [Test]
        public void GivenInvalidTimeSlot_ShouldReturnTrue()
        {
            //Arrange
            var input = 12345;
            //Act
            var result = RequestValidator.IsTimeSlotValid((TimeSlotEnums)input);
            //Assert
            result.ShouldBeFalse();
        }
        
        [Test]
        public void GivenValidTimeSlot_ShouldReturnTrue()
        {
            //Arrange
            var input = 123;
            //Act
            var result = RequestValidator.IsTimeSlotValid((TimeSlotEnums) input);
            //Assert
            result.ShouldBeTrue();
        }
    }
}