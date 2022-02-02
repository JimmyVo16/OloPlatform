using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace OloPlatform.Repositories
{
    public class RepositoryUtilities : IRepositoryUtilities
    {
        private readonly string _connectionString;
        
        public RepositoryUtilities(IConfiguration configuration)
        {
            _connectionString = configuration["DefaultConnection:ConnectionString"]; 
        }
        

        public async Task<T> QuerySingleOrDefaultAsync<T>(string command, object @params = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<T>(command, @params);
                
                return result.SingleOrDefault();
            }
        }
    }
}