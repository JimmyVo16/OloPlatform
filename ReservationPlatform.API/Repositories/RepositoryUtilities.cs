using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using OloPlatform.Services;

namespace OloPlatform.Repositories
{
    public class RepositoryUtilities : IRepositoryUtilities
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private string ConnectionString => _configuration["DefaultConnection:ConnectionString"];
        
        public RepositoryUtilities(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        
        public async Task<T> QuerySingleOrDefaultAsync<T>(string command, object @params = null) where T: class, new()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    var result = await connection.QueryAsync<T>(command, @params);

                    if (result.Any())
                    {
                        return result.Single();
                    }
                    _logger.LogWarning($"No result were found for command {command}", @params);
                    
                    return new T(); 
                }
                catch (Exception e)
                {
                    _logger.LogError($"Exception what thrown for command: {command}", e,  @params);
                    return new T();    
                }
            }
        }

        public async Task<T> QuerySinglePrimitiveAsync<T>(string command, object @params = null) where T : struct
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    var result = await connection.QueryAsync<T>(command, @params);

                    if (result.Any())
                    {
                        return result.Single();
                    }
                    _logger.LogWarning($"No result were found for command {command}", @params);
                    
                    return default;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Exception what thrown for command: {command}", e,  @params);
                    return default;
                }
            }
        }
    }
}