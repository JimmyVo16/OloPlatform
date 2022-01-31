using System.Net;
using Microsoft.AspNetCore.Http;
using OloPlatform.Models;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OloPlatform.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {
        private readonly IRepositoryUtilities _repositoryUtilities;

        public ReservationsRepository(IRepositoryUtilities repositoryUtilities)
        {
            _repositoryUtilities = repositoryUtilities;
        }

        public async Task<ReservationResponseDto> BookReservation(
            ReservationRequestDto requestDto, 
            int customerId,
            int timeSlotSection)
        {
            // Jimmy make sure to clean this out
            // Jimmy vo potentially move this up to the service level

            const string Query = @"update TOP (1) res
                                   SET res.CustomerId = @CustomerId
                                   FROM Reservations res
                                   WHERE res.RestaurantId = @RestaurantId
	                                   AND res.CustomerId IS NULL
	                                   AND res.PartySize = @PartySize
	                                   AND res.TimeSlotSection = @TimeSlotSection
                                   SELECT  @@ROWCOUNT";

            // Check if it's available. return 404 if it isn't 

            var input = new
            {
                CustomerId = customerId,
                RestaurantId = requestDto.RestaurantId,
                PartySize = requestDto.PartySize,
                TimeSlotSection = timeSlotSection
            };
            
            var result = await _repositoryUtilities.QueryAsync<bool>(Query, input);

            // update if it is. 


            // return wehter it was successful or not


            return new ReservationResponseDto()
            {
                StatusCodes = HttpStatusCode.Accepted,
                Result = result.ToString(),
            };
        }

        public async Task<int> GetCustomerId(ReservationRequestDto requestDto)
        {
            const string Query = @"SELECT c.CustomerId 
                                   FROM Customers c
                                   WHERE c.CustomerName = @CustomerName
                                       AND c.EmailAddress = @EmailAddress";

            return await _repositoryUtilities.QueryAsync<int>(Query,
                new {CustomerName = requestDto.CustomerName, EmailAddress = requestDto.EmailAddress});
        }
    }
}