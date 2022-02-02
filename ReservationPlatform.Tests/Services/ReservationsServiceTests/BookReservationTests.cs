using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using OloPlatform.Enums;
using OloPlatform.Models;
using OloPlatform.Repositories;
using OloPlatform.Services;
using Shouldly;

namespace ReservationPlatform.Tests.Services.ReservationsServiceTests
{
    [TestFixture]
    public class BookReservationTests
    {
        [Test]
        public async Task Given_ReservationRequestAndUser_ShouldBookReservationForUser()
        {
            //Arrange
            var repo = Substitute.For<IReservationsRepository>();

            var expectedBookedReservation = new BookReservationDto
            {
                ReservationId = 123,
                IsSuccess = true
            };
            const int expectedCustomerId = 12;

            repo.GetCustomerId(
                    Arg.Any<ReservationRequestDto>())
                .Returns(expectedCustomerId);

            repo.BookReservation(
                    Arg.Any<ReservationRequestDto>(),
                    Arg.Any<int>())
                .Returns(expectedBookedReservation);


            var request = new ReservationRequestDto
            {
                CustomerRequestedTimeSlot = TimeSlotEnums.Hour2TimeSlot1
            };

            var reservationsService = new ReservationsService(repo);

            //Act
            var result = await reservationsService.BookReservation(request);

            //Assert
            result.GetHashCode().ShouldBe(expectedBookedReservation.GetHashCode());

            await repo.Received(1)
                .GetCustomerId(Arg.Is<ReservationRequestDto>(i => i.GetHashCode() == request.GetHashCode()));

            await repo.Received(1)
                .BookReservation(
                    Arg.Is<ReservationRequestDto>(i => i.GetHashCode() == request.GetHashCode()),
                    Arg.Is<int>(i => i == expectedCustomerId));
        }
    }
}