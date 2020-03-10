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
    public class CertificationRepository : IRepository
    {
        private readonly IConfiguration _config;

        public CertificationRepository(IConfiguration config)
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

        public async Task<IEnumerable<Certification>> GetCertifications()
        {
            using(IDbConnection conn =  new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
            {
                string query = "Select * from Certification";
                conn.Open();
                var results = await conn.QueryAsync<Certification>(query);
                return results;
            }
        }

        public async Task<Certification> GetCertificationById(string id)
        {
            using(IDbConnection conn = new SQLiteConnection("Data Source=C:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;"))
            {
                string query = "Select * Certification WHERE ID = @ID";
                conn.Open();
                var result = await conn.QueryAsync<Certification>(query, new {ID = id});
                return result.FirstOrDefault();
            }
        }
    }
}