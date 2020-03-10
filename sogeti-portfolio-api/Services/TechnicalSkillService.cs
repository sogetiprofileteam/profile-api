using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.DTOs;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class TechnicalSkillService
    {
        private readonly TechnicalSkillsRepository _repository;
        private readonly IMapper _mapper;
        public TechnicalSkillService(TechnicalSkillsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TechnicalSkillDTO>> GetTechnicalSkills()
        {
            var reader = await _repository.GetTechnicalSkills();
            var consulants = new List<TechnicalSkillDTO>();

            if(reader != null)
            {
                consulants = _mapper.Map<IEnumerable<TechnicalSkill>, List<TechnicalSkillDTO>>(reader);
            }
            return consulants;
        }

        public async Task<TechnicalSkillDTO> GetTechnicalSkill(string id)
        {
            var reader = await _repository.GetTechnicalSkillById(id);
            var consulant = new TechnicalSkillDTO();

            if(reader != null)
            {
                consulant = _mapper.Map<TechnicalSkill, TechnicalSkillDTO>(reader);
            }
            return consulant;
        }
    }
}
