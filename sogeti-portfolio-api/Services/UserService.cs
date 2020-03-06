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
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var reader = await _repository.GetUsers();
            var userList = new List<UserDTO>();
            // TODO use dapper or automapper to map each row in the reader to a USer
            if(reader != null)
            {
                userList.Add(_mapper.Map<UserDTO>(reader));
            }

            return userList;
        }
    }
}
