using System.Net.Http;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class CertificationService : AbstractElasticService<Certification>
    {
        public CertificationService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            Path = "certification";
        }
    }
}
