using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using AutoMapper;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.DTOs;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(UserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var reader = await _repository.GetUsers();
            var userList = new List<UserDTO>();
            if(reader != null)
            {
                userList = _mapper.Map<IEnumerable<User>, List<UserDTO>>(reader);
            }
            return userList;
        }

        public async Task<UserDTO> GetUser(string id)
        {
            var reader = await _repository.GetUserById(id);
            var user = new UserDTO();
            if(reader != null)
            {
                user = _mapper.Map<User, UserDTO>(reader);
            }
            return user;
        }
    }
}
