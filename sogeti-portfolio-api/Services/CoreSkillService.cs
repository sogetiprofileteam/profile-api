using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.DTOs;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class CoreSkillService
    {
        private readonly CoreSkillsRepository _repository;
        private readonly IMapper _mapper;
        public CoreSkillService(CoreSkillsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CoreSkillDTO>> GetCoreSkills()
        {
            var reader = await _repository.GetCoreSkills();
            var consulants = new List<CoreSkillDTO>();

            if(reader != null)
            {
                consulants = _mapper.Map<IEnumerable<CoreSkill>, List<CoreSkillDTO>>(reader);
            }
            return consulants;
        }

        public async Task<CoreSkillDTO> GetCoreSkill(string id)
        {
            var reader = await _repository.GetCoreSkillById(id);
            var consulant = new CoreSkillDTO();

            if(reader != null)
            {
                consulant = _mapper.Map<CoreSkill, CoreSkillDTO>(reader);
            }
            return consulant;
        }
    }
}
