using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Interfaces
{
    public interface IElasticService<T> where T : AbstractModel
    {
        Task<IEnumerable<JToken>> GetAsync();

        Task<JToken> GetAsync(string id);

        Task CreateAsync(T model);

        Task UpdateAsync(T model);

        Task DeleteAsync(string id);
    }
}
