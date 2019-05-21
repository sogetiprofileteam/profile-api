using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers
{
    [Route ("consultant")]
    [ApiController]
    public class ConsultantController : ControllerBase 
    {
        private readonly IConsultantService _consultantService;

        public ConsultantController (IConsultantService consultantService) => _consultantService = consultantService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var profiles = await _consultantService.GetConsultantsAsync();

            if (profiles.Any())
                return Ok(profiles);

            return NotFound();
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var profile = await _consultantService.GetConsultantAsync(id);

            if (profile != null)
                return Ok(profile);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Consultant consultant)
        {
            await _consultantService.CreateConsultantAsync(consultant);
            return CreatedAtAction(nameof(Get), consultant);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Consultant consultant)
        {
            await _consultantService.UpdateConsultantAsync(consultant);
            return Ok();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _consultantService.DeleteConsultantAsync(id);
            return Ok();
        }

    }
}