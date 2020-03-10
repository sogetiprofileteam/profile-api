using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Services;
using AutoMapper;
using System.Collections.Generic;
using sogeti_portfolio_api.DTOs;


namespace sogeti_portfolio_api.Controllers
{
    [Route ("education")]
    [ApiController]
    public class EducationController : Controller
    {
        private readonly EducationService _service;
        private readonly IMapper _mapper;
        public EducationController (EducationService service , IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EducationDTO>> GetEducations()
        {
            return await _service.GetEducations();
        }

        [HttpGet("{id}")]
        public async Task<EducationDTO> GetEducation(string name)
        {
            return await _service.GetEducation(name);
        }
    }
}
