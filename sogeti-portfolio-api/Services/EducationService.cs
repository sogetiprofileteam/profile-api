using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.DTOs;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class EducationService
    {
        private readonly EducationRepository _repository;
        private readonly IMapper _mapper;
        public EducationService(EducationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EducationDTO>> GetEducations()
        {
            var reader = await _repository.GetEducations();
            var consulants = new List<EducationDTO>();

            if(reader != null)
            {
                consulants = _mapper.Map<IEnumerable<Education>, List<EducationDTO>>(reader);
            }
            return consulants;
        }

        public async Task<EducationDTO> GetEducation(string id)
        {
            var reader = await _repository.GetEducationById(id);
            var consulant = new EducationDTO();

            if(reader != null)
            {
                consulant = _mapper.Map<Education, EducationDTO>(reader);
            }
            return consulant;
        }
    }
}
