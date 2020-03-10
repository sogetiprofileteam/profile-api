using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Services;
using AutoMapper;
using System.Collections.Generic;
using sogeti_portfolio_api.DTOs;

namespace sogeti_portfolio_api.Controllers
{
    [Route ("consultant")]
    [ApiController]
    public class ConsultantController : Controller
    {
        private readonly ConsultantService _service;
        private readonly IMapper _mapper;
        public ConsultantController (ConsultantService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ConsultantDTO>> GetConsultants()
        {
            return await _service.GetConsultants();
        }

        [HttpGet("{id}")]
        public async Task<ConsultantDTO> GetConsultant(string id)
        {
            return await _service.GetConsultant(id);
        }
    }
}
