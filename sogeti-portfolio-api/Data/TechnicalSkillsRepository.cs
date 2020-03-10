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
    public class TechnicalSkillsRepository : IRepository
    {
        private readonly IConfiguration _config;
        public TechnicalSkillsRepository(IConfiguration config)
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

        public async Task<IEnumerable<TechnicalSkill>> GetTechnicalSkills()
        {
            using(IDbConnection conn =  new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
            {
                string query = "Select Id as GuidString, name, display, displayOrder from Technicalskill";
                conn.Open();
                var results = await conn.QueryAsync<TechnicalSkill>(query);
                return results;
            }
        }

        public async Task<TechnicalSkill> GetTechnicalSkillById(string id)
        {
            using(IDbConnection conn = new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
            {
                string query = "Select Id as GuidString, name, display, displayOrder from Technicalskill WHERE id = @ID";
                conn.Open();
                var result = await conn.QueryAsync<TechnicalSkill>(query, new {id = id});
                return result.FirstOrDefault();
            }
        }
    }
}