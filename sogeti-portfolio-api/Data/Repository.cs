using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Data
{
   public class Repository : IRepository
   {
      private readonly string _connectionString = "Data Source=:<your .sqlite file>:";
      
      public Repository()
      {
         
      }

      public Task<DbDataReader> GetUsers()
      {
         string stm = "SELECT ID, Name from tUser";

         using var con = new SQLiteConnection(_connectionString);
         con.Open();
         
         using var cmd = new SQLiteCommand(stm, con);
         string version = cmd.ExecuteScalar().ToString();

         return cmd.ExecuteReaderAsync();
      }
   }
}