using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Interfaces
{
    public interface IService<T> where T : AbstractModel
    {
        Task<IEnumerable<JToken>> GetAsync();

        Task<JToken> GetAsync(string id);

        Task CreateAsync(HttpContent model);

        Task UpdateAsync(HttpContent model);

        Task DeleteAsync(string id);
    }
}
