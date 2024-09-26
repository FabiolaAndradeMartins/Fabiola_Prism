using Fabiola_Prism.Models;
using System.Threading.Tasks;

namespace Fabiola_Prism.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }
}
