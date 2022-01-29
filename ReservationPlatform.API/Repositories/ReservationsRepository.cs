using System.Net;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models;
using System;
using System.Data.SqlClient;
using System.Text;

namespace WebApplication1.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {
        public ReservationResponse CreateReservation(ReservationRequestDto requestDto)
        {
            // Jimmy make sure you make this cleaner
            var builder = new SqlConnectionStringBuilder();

            builder.DataSource = "localhost";
            builder.InitialCatalog = "SPGDB";
            builder.IntegratedSecurity = true;
            var test = string.Empty;
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();       

                var sql = "SELECT name, collation_name FROM sys.databases";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            test = $"{reader.GetString(0)} {reader.GetString(1)}";
                            break;
                        }
                    }
                }                    
            }
            
            return new ReservationResponse()
            {
                StatusCodes = HttpStatusCode.Accepted,
                Result = test,
            };
        }
    }
}