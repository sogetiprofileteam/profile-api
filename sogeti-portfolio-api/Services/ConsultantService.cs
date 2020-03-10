using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.DTOs;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class ConsultantService
    {
        private readonly ConsultantRepository _repository;
        private readonly IMapper _mapper;
        public ConsultantService(ConsultantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConsultantDTO>> GetConsultants()
        {
            var reader = await _repository.GetConsultants();
            var consulants = new List<ConsultantDTO>();

            if(reader != null)
            {
                consulants = _mapper.Map<IEnumerable<Consultant>, List<ConsultantDTO>>(reader);
            }
            return consulants;
        }

        public async Task<ConsultantDTO> GetConsultant(string id)
        {
            var reader = await _repository.GetConsultantById(id);
            var consulant = new ConsultantDTO();

            if(reader != null)
            {
                consulant = _mapper.Map<Consultant, ConsultantDTO>(reader);
            }
            return consulant;
        }
    }
}
