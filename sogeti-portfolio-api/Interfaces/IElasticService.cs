using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace sogeti_portfolio_api.Interfaces
{
    public interface IElasticService<T>
    {
        Task<IEnumerable<string>> GetAsync();

        Task<string> GetAsync(string id);

        Task CreateAsync(T model);

        Task UpdateAsync(T model);

        Task DeleteAsync(string id);
    }
}