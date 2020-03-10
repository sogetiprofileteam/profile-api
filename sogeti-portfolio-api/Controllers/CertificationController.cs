using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Services;
using AutoMapper;
using System.Collections.Generic;
using sogeti_portfolio_api.DTOs;

namespace sogeti_portfolio_api.Controllers {
    [Route ("certification")]
    [ApiController]
    public class CertificationController  : Controller
    {
        private readonly CertificationService _service;
        private readonly IMapper _mapper;
        public CertificationController (CertificationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CertificationDTO>> GetCertifications()
        {
            return await _service.GetCertifications();
        }

        [HttpGet("{id}")]
        public async Task<CertificationDTO> GetCertification(string id)
        {
            return await _service.GetCertification(id);
        }
    }
}