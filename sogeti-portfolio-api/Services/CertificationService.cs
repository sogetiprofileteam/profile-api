using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.DTOs;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class CertificationService
    {
       private readonly CertificationRepository _repository;
        private readonly IMapper _mapper;
        public CertificationService(CertificationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CertificationDTO>> GetCertifications()
        {
            var reader = await _repository.GetCertifications();
            var consulants = new List<CertificationDTO>();

            if(reader != null)
            {
                consulants = _mapper.Map<IEnumerable<Certification>, List<CertificationDTO>>(reader);
            }
            return consulants;
        }

        public async Task<CertificationDTO> GetCertification(string id)
        {
            var reader = await _repository.GetCertificationById(id);
            var consulant = new CertificationDTO();

            if(reader != null)
            {
                consulant = _mapper.Map<Certification, CertificationDTO>(reader);
            }
            return consulant;
        }
    }
}
