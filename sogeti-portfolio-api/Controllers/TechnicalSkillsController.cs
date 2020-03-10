using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Services;
using AutoMapper;
using System.Collections.Generic;
using sogeti_portfolio_api.DTOs;

namespace sogeti_portfolio_api.Controllers {
    [Route ("technicalskills")]
    [ApiController]
    public class TechnicalSkillsController : Controller 
    {
        private readonly TechnicalSkillService _service;
        private readonly IMapper _mapper;
        public TechnicalSkillsController (TechnicalSkillService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TechnicalSkillDTO>> GetTechnicalSkills()
        {
            return await _service.GetTechnicalSkills();
        }

        [HttpGet("{id}")]
        public async Task<TechnicalSkillDTO> GetTechnicalSkill(string id)
        {
            return await _service.GetTechnicalSkill(id);
        }
    }
}
