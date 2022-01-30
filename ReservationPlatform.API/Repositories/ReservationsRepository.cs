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

        public async Task<ReservationResponseDto> CreateReservation(ReservationRequestDto requestDto)
        {
            // Jimmy make sure to clean this out
            // Jimmy vo potentially move this up to the service level
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                
                // Restaurant doesn't exist
                // Timeslot doesn't exist
                // Reservation is not available
                // 
                
                var findCommand = "SELECT top 1 name FROM sys.databases";
             
                // Check if it's available. return 404 if it isn't 
                
                var test = await _repositoryUtilities.QueryAsync<string>(findCommand);

                // update if it is. 
                
                
                // return wehter it was successful or not
                scope.Complete();

                return new ReservationResponseDto()
                {
                    StatusCodes = HttpStatusCode.Accepted,
                    Result = test,
                };
            }
        }
    }
}