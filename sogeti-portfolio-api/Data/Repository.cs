using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Data
{
   public class Repository : IRepository
   {
      //private readonly string _connectionString = "Data Source=c:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;";
      
      private readonly IConfiguration _config;
      public Repository(IConfiguration config)
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

      public async Task<IEnumerable<DbDataReader>> GetUsers()
      {
         // string stm = "SELECT id from User";

         // using var con = new SQLiteConnection(_connectionString);
         // con.Open();
         
         // using var cmd = new SQLiteCommand(stm, con);
         // string version = cmd.ExecuteScalar().ToString();

         // return cmd.ExecuteReaderAsync();
          using(IDbConnection conn =  new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
         {
            string query = "Select id, firstname, lastname from Users";
            conn.Open();
            var results = await conn.QueryAsync<DbDataReader>(query);
            return results;
         }
      }

      public async Task<User> GetUserById(string id)
      {
         using(IDbConnection conn = connection)
         {
            string query = "Select id, firstname, lastname from Users WHERE ID = @ID";
            conn.Open();
            var result = await conn.QueryAsync<User>(query, new {ID = id});
            return result.FirstOrDefault();
         }
      }
   }
}