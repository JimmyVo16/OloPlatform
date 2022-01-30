using System.Threading.Tasks;

namespace OloPlatform.Repositories
{
    public interface IRepositoryUtilities
    {
        public Task<T> QueryAsync<T>(string command, object @params = null);
    }
}