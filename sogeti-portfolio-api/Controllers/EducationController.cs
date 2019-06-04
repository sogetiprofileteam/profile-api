using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers
{
    [Route ("education")]
    [ApiController]
    public class EducationController : ControllerBase {

        private readonly IElasticService<Education> _educationService;
        public EducationController (IElasticService<Education> educationService) => _educationService = educationService;

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var educations = await _educationService.GetAsync();

            if (educations.Any())
                return Ok(educations);

            return NotFound();
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(string id) 
        {
            var education = await _educationService.GetAsync(id);

            if (education != null)
                return Ok(education);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Education school)
        {
            await _educationService.CreateAsync(school);
            return CreatedAtAction(nameof(Get), school);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Education school)
        {
            await _educationService.UpdateAsync(school);
            return Ok();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _educationService.DeleteAsync(id);
            return Ok();
        }

    }
}