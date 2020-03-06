using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;
using AutoMapper;
using sogeti_portfolio_api.DTOs;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SQLite;
using System.Data;
using System.Collections.Generic;
using System.Net.Http;
using sogeti_portfolio_api.Services;

namespace sogeti_portfolio_api.Controllers {
    [Route ("users")]
    [ApiController]
    public class UserController : Controller  {

        private readonly UserService _service;
        private readonly IMapper _mapper;

        private readonly string _connectionString = "Data Source=c:\\Users\\tyalexan\\Desktop\\testtesttest.db;Version=3;";

        public UserController(UserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            // DataTable dt = new DataTable();
            // string stm = "SELECT id, firstname, lastname, email from Users";

            // using var con = new SQLiteConnection(_connectionString);
            // con.Open();
            
            // using var cmd = new SQLiteCommand(stm, con);
            // SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            // da.Fill(dt);

            // var lu = new List<UserDTO>();

            // if(dt.Rows.Count > 0)
            // {
            //     foreach(DataRow dr in dt.Rows)
            //     {
            //         User user = new User() {
            //             Id = new System.Guid(dr["id"].ToString()),
            //             FirstName = dr["firstname"].ToString(),
            //             LastName = dr["lastname"].ToString(),
            //             Email = dr["email"].ToString()
            //         };
            //         var userDto = _mapper.Map<UserDTO>(user);

            //         lu.Add(userDto);
            //     }
            // }

            return await _service.GetUsers();

            
            //return lu;
        }

        [HttpGet ("{id}")]
        public async Task<IEnumerable<UserDTO>> GetUser(string id)
        {
            DataTable dt = new DataTable();
            //DbDataReader reader = await _repository.GetUsers();
            string stm = "SELECT id, firstname, lastname, email from Users WHERE firstname='"+id+"'";

            using var con = new SQLiteConnection(_connectionString);
            con.Open();
            
            using var cmd = new SQLiteCommand(stm, con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);

            var lu = new List<UserDTO>();

            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    User user = new User() {
                        Id = new System.Guid(dr["id"].ToString()),
                        FirstName = dr["firstname"].ToString(),
                        LastName = dr["lastname"].ToString(),
                        Email = dr["email"].ToString()
                    };
                    var userDto = _mapper.Map<UserDTO>(user);

                    lu.Add(userDto);
                }
            }            
            return lu;
        }

        // [HttpPost]
        // public async Task<IEnumerable<UserDTO>> PostUser(HttpContent content)
        // {
            
        // }

    }
}