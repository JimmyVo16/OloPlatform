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

        public async Task<BookReservationDto> BookReservation(
            ReservationRequestDto requestDto,
            int customerId)
        {
            const string query = 
                @" DECLARE @ReservationId INT
                   UPDATE 
                       TOP (1) res
                   SET 
                       res.CustomerId = @CustomerId,
                       @ReservationId = res.ReservationId
                   FROM 
                       Reservations res
                   WHERE res.RestaurantId = @RestaurantId
	                   AND res.CustomerId IS NULL
	                   AND res.PartySize = @PartySize
	                   AND res.TimeSlotSection = @TimeSlotSection
                   SELECT  @@ROWCOUNT IsSuccess,  @ReservationId ReservationId";
            
            var input = new
            {
                CustomerId = customerId,
                RestaurantId = requestDto.RestaurantId,
                PartySize = requestDto.PartySize,
                TimeSlotSection = requestDto.CustomerRequestedTimeSlot
            };
            
            return await _repositoryUtilities.QuerySingleOrDefaultAsync<BookReservationDto>(query, input);
        }

        public async Task<int> GetCustomerId(ReservationRequestDto requestDto)
        {
            const string query = @"SELECT c.CustomerId 
                                   FROM Customers c
                                   WHERE c.CustomerName = @CustomerName
                                       AND c.EmailAddress = @EmailAddress";

            return await _repositoryUtilities.QuerySingleOrDefaultAsync<int>(query,
                new {CustomerName = requestDto.CustomerName, EmailAddress = requestDto.EmailAddress});
        }
    }
}