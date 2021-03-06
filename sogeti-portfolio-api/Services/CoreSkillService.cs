using System.Net.Http;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class CoreSkillService : AbstractElasticService<CoreSkill>
    {
        public CoreSkillService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            Path = "coreskill";
        }
    }
}
