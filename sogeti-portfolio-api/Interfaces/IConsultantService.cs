using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Interfaces
{
    public interface IConsultantService
    {
        Task<IEnumerable<JToken>> GetConsultantsAsync();

        Task<JToken> GetConsultantAsync(string id);

        Task CreateConsultantAsync(Consultant consultant);

        Task UpdateConsultantAsync(Consultant consultant);

        Task DeleteConsultantAsync(string id);
    }
}