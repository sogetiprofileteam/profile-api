using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Data
{
   public interface IRepository
   {
      Task<IEnumerable<DbDataReader>> GetUsers();
      Task<User> GetUserById(string id);

   }
}