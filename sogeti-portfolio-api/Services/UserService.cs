using System.Net.Http;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class UserService : AbstractSqlService<User>
    {
        public UserService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            Path = "user";
        }
    }
}
