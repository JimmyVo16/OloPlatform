using System;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
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
                    Arg.Any<int>(),
                    Arg.Any<int>())
                .Returns(expectedBookedReservation);
            
            
            var request = new ReservationRequestDto
            {
                CustomerRequestedTime = DateTime.Now
            };

            var reservationsService = new ReservationsService(repo);
            
            //Act
            var result = await reservationsService.BookReservation(request);
            
            //Assert
            result.GetHashCode().ShouldBe(expectedBookedReservation.GetHashCode());
            //Jimmy maybe assert that the input is correct?
        }
    }
}