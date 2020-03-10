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
    public class EducationRepository : IRepository
    {
        private readonly IConfiguration _config;

        public EducationRepository(IConfiguration config)
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

        public async Task<IEnumerable<Education>> GetEducations()
        {
            using(IDbConnection conn =  new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
            {
                string query = "Select * from Education";
                conn.Open();
                var results = await conn.QueryAsync<Education>(query);
                return results;
            }
        }

        public async Task<Education> GetEducationById(string id)
        {
            using(IDbConnection conn = new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
            {
                string query = "Select * from Education WHERE ID = @ID";
                conn.Open();
                var result = await conn.QueryAsync<Education>(query, new {ID = id});
                return result.FirstOrDefault();
            }
        }
    }
}