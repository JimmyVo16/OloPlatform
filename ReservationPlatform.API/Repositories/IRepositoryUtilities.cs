using System.Threading.Tasks;

namespace OloPlatform.Repositories
{
    public interface IRepositoryUtilities
    {
        public Task<T> QuerySingleAsync<T>(string command, object @params = null);
    }
}