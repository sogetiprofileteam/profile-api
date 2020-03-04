using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class UserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            DbDataReader reader = await _repository.GetUsers();
            
            // TODO use dapper or automapper to map each row in the reader to a USer
            return null;
        }
    }
}
