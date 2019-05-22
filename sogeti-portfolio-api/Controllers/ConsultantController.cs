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
        private readonly IElasticService<Consultant> _consultantService;
        public ConsultantController (IElasticService<Consultant> consultantService) => _consultantService = consultantService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var profiles = await _consultantService.GetAsync();

            if (profiles.Any())
                return Ok(profiles);

            return NotFound();
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var profile = await _consultantService.GetAsync(id);

            if (profile != null)
                return Ok(profile);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Consultant consultant)
        {
            await _consultantService.CreateAsync(consultant);
            return CreatedAtAction(nameof(Get), consultant);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Consultant consultant)
        {
            await _consultantService.UpdateAsync(consultant);
            return Ok();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _consultantService.DeleteAsync(id);
            return Ok();
        }

    }
}