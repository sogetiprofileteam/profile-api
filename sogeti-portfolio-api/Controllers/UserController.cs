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
    public class UserController : Controller  
    {

        private readonly UserService _service;
        private readonly IMapper _mapper;

        public UserController(UserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
               return await _service.GetUsers();
        }

        [HttpGet ("{id}")]
        public async Task<UserDTO> GetUser(string id)
        {
            return await _service.GetUser(id);
        }

        // [HttpPost]
        // public async Task<IEnumerable<UserDTO>> PostUser(HttpContent content)
        // {
            
        // }

    }
}