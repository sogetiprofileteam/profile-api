using System.Net.Http;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class ConsultantService : AbstractSqlService<Consultant>
    {
        public ConsultantService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            Path = "consultant";
        }
    }
}
