using System.Data.Common;
using System.Threading.Tasks;

namespace sogeti_portfolio_api.Data
{
   public interface IRepository
   {
      Task<DbDataReader> GetUsers();
   }
}