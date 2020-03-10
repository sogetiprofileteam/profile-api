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
    public class CoreSkillsRepository : IRepository
    {
      //private readonly string _connectionString = "Data Source=c:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;";
      
        private readonly IConfiguration _config;
        public CoreSkillsRepository(IConfiguration config)
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

        public async Task<IEnumerable<CoreSkill>> GetCoreSkills()
        {
            using(IDbConnection conn =  new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
            {
                string query = "Select Id as GuidString, name, display, displayOrder from Coreskill";
                conn.Open();
                var results = await conn.QueryAsync<CoreSkill>(query);
                return results;
            }
        }

        public async Task<CoreSkill> GetCoreSkillById(string id)
        {
            using(IDbConnection conn = new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
            {
                string query = "Select Id as GuidString, name, display, displayOrder from Coreskill WHERE id = @ID";
                conn.Open();
                var result = await conn.QueryAsync<CoreSkill>(query, new {id = id});
                return result.FirstOrDefault();
            }
        }
    }
}