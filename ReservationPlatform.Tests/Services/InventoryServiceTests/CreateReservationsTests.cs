using System;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using OloPlatform.Models;
using OloPlatform.Repositories;
using OloPlatform.Services;
using Shouldly;

namespace ReservationPlatform.Tests.Services.InventoryServiceTests
{
    [TestFixture]
    public class CreateReservationsTests
    {
        [Test]
        public async Task GivenInventoryRequest_ShouldCreateDesiredNumberOfReservations()
        {
            //Arrange
            var repo = Substitute.For<IInventoryRepository>();
            var logger = Substitute.For<ILogger>();
            
            var createdReservationDto = new CreatedReservationDto
            {
                ReservationId = 12,
                IsSuccess = true
            };

            repo.CreateReservation(Arg.Any<CreatedReservationRequestDto>())
                .Returns(createdReservationDto);

            const int expectedRestaurantId = 1;
            
            var request = new InventoryRequestDto
            {
                RestaurantId = expectedRestaurantId,
                
                TimeSlots = new []
                {
                    new ReservationTimeSlotRequestDto()
                    {
                        ReservationCount = 3,
                    },
                    new ReservationTimeSlotRequestDto()
                    {
                        ReservationCount = 2,
                        
                    },
                }
            };
            var service = new InventoryService(repo, logger);
            
            //Act
            var result = (await service.CreateReservations(request)).ToArray();

            //Assert
            result.Count().ShouldBe(5);

            result.All(i => i.ReservationId == createdReservationDto.ReservationId)
                .ShouldBeTrue();
        }
        
        [Test]
        public async Task GivenInventoryRequest_WithFailedCreation_ShouldOnlySuccess()
        {
            //Arrange
            var repo = Substitute.For<IInventoryRepository>();
            var logger = Substitute.For<ILogger>();
            
            var createdReservation = new CreatedReservationDto
            {
                ReservationId = 12,
                IsSuccess = true
            };
            
            var failedReservation = new CreatedReservationDto
            {
                ReservationId = 12,
                IsSuccess = false
            };

            repo.CreateReservation(Arg.Any<CreatedReservationRequestDto>())
                .Returns(
                    createdReservation, 
                    createdReservation,
                    failedReservation);

            const int expectedRestaurantId = 1;
            
            var request = new InventoryRequestDto
            {
                RestaurantId = expectedRestaurantId,
                
                TimeSlots = new []
                {
                    new ReservationTimeSlotRequestDto()
                    {
                        ReservationCount = 3,
                    },
                    new ReservationTimeSlotRequestDto()
                    {
                        ReservationCount = 2,
                        
                    },
                }
            };
            var service = new InventoryService(repo, logger);
            
            //Act
            var result = (await service.CreateReservations(request)).ToArray();

            //Assert
            result.Count().ShouldBe(2);

            result.All(i => i.ReservationId == createdReservation.ReservationId)
                .ShouldBeTrue();
            
            logger.Received(3).LogWarning(
                Arg.Is<string>(i => i == "Create reservation for request."),
                Arg.Any<object>());
        }
    }
}