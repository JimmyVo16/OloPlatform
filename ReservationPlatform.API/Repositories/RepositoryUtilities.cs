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
        
        public async Task<T> QuerySingleOrDefaultAsync<T>(string command, object @params = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = await connection.QueryAsync<T>(command, @params);

                if (!result.Any())
                {
                    _logger.LogWarning($"No result were found for command {command}", @params);
                }

                return result.SingleOrDefault();
            }
        }
    }
}