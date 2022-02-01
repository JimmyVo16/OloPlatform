using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;

namespace OloPlatform.Repositories
{
    public class RepositoryUtilities : IRepositoryUtilities
    {
        // Jimmy clean this up
        private  string connectionString = "Data Source=localhost;Initial Catalog=Olo;Integrated Security=True";
        
        //Jimmy look into the object
        public async Task<T> QuerySingleAsync<T>(string command, object @params = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.QueryAsync<T>(command, @params);
                
                return result.SingleOrDefault();
            }
        }
    }
}