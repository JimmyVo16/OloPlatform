using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;

namespace OloPlatform.Repositories
{
    public class RepositoryUtilities : IRepositoryUtilities
    {
        //Jimmy look into the object
        public async Task<T> QueryAsync<T>(string command, object @params = null)
        {
            // Jimmy clean this up
            var connectionString = "Data Source=localhost;Initial Catalog=SPGDB;Integrated Security=True";
            
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.QueryAsync<T>(command, @params);
                
                return result.SingleOrDefault();
            }
        }
    }
}