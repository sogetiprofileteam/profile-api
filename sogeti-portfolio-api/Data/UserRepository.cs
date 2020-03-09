using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Data
{
   public class UserRepository : IRepository
   {
      //private readonly string _connectionString = "Data Source=c:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;";
      
      private readonly IConfiguration _config;
      public UserRepository(IConfiguration config)
      {
         _config = config;
      }

      public IDbConnection connection
      {
         get
         {
            return new SQLiteConnection(_config.GetConnectionString("sqlite"));
         }
      }

      public async Task<IEnumerable<User>> GetUsers()
      {
         using(IDbConnection conn =  new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
         {
            string query = "Select id as GuidString, firstname, lastname, username, email, role from Users";
            conn.Open();
            var results = await conn.QueryAsync<User>(query);
            return results;
         }
      }

      public async Task<User> GetUserById(string id)
      {
         using(IDbConnection conn = new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
         {
            string query = "Select id as GuidString, firstname, lastname, username, email, role from Users WHERE ID = @ID";
            conn.Open();
            var result = await conn.QueryAsync<User>(query, new {ID = id});
            return result.FirstOrDefault();
         }
      }
    }
}