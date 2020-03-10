using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.DTOs;
using sogeti_portfolio_api.Services;
using AutoMapper;
using System.Collections.Generic;

namespace sogeti_portfolio_api.Controllers
{
    [Route ("coreskills")]
    [ApiController]
    public class CoreSkillsController : Controller
    {
        private readonly CoreSkillService _service;
        private readonly IMapper _mapper;
        public CoreSkillsController(CoreSkillService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CoreSkillDTO>> GetCoreSkills()
        {
            return await _service.GetCoreSkills();
        }

        [HttpGet("{id}")]
        public async Task<CoreSkillDTO> GetCoreSkill(string id)
        {
            return await _service.GetCoreSkill(id);
        }
    }
}
