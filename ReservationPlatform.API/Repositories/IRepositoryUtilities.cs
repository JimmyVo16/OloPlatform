using System.Threading.Tasks;

namespace OloPlatform.Repositories
{
    public interface IRepositoryUtilities
    {
        public Task<T> QuerySingleOrDefaultAsync<T>(string command, object @params = null) where T: class, new();

        public Task<T> QuerySinglePrimitiveAsync<T>(string command, object @params = null) where T: struct;
    }
}