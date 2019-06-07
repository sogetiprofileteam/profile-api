using System.Net.Http;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class TechnicalSkillService : AbstractElasticService<TechnicalSkill>
    {
        public TechnicalSkillService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            Path = "technicalskill";
        }
    }
}
