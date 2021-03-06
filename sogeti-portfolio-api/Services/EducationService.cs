using System.Net.Http;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class EducationService : AbstractElasticService<Education>
    {
        public EducationService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            Path = "education";
        }
    }
}
