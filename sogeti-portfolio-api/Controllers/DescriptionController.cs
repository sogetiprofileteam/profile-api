using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers
{
    [Route ("description")]
    [ApiController]
    public class DescriptionController : ControllerBase {

        private readonly IElasticService<Description> _descriptionService;
        public DescriptionController (IElasticService<Description> descriptionService) => _descriptionService = descriptionService;

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var descriptions = await _descriptionService.GetAsync();

            if (descriptions.Any())
                return Ok(descriptions);

            return NotFound();
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(string id) 
        {
            var description = await _descriptionService.GetAsync(id);

            if (description != null)
                return Ok(description);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Description summary)
        {
            await _descriptionService.CreateAsync(summary);
            return CreatedAtAction(nameof(Get), summary);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Description summary)
        {
            await _descriptionService.UpdateAsync(summary);
            return Ok();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _descriptionService.DeleteAsync(id);
            return Ok();
        }

    }
}