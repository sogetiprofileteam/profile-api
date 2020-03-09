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
    public class ConsultantRepository : IRepository
    {
      //private readonly string _connectionString = "Data Source=c:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;";
      
        private readonly IConfiguration _config;
        public ConsultantRepository(IConfiguration config)
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

        public async Task<IEnumerable<Consultant>> GetConsultants()
        {
            using(IDbConnection conn =  new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
            {
                string query = "Select Id as GuidString, firstname, lastname, status, phone, title, practice, email, summary, urlLinkedIn, urlGithub, urlWordpress, urlPersonal from Consultant";
                conn.Open();
                var results = await conn.QueryAsync<Consultant>(query);
                return results;
            }
        }

        public async Task<Consultant> GetConsultantById(string id)
        {
            using(IDbConnection conn = new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
            {
                string query = "Select Id as GuidString, firstname, lastname, status, phone, title, practice, email, summary, urlLinkedIn, urlGithub, urlWordpress, urlPersonal from Consultant WHERE ID = @ID";
                conn.Open();
                var result = await conn.QueryAsync<Consultant>(query, new {ID = id});
                return result.FirstOrDefault();
            }
        }
    }
}