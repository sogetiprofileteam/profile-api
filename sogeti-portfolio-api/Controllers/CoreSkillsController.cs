using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers
{
    [Route ("coreskills")]
    [ApiController]
    public class CoreSkillsController : ControllerBase {

        private readonly IElasticService<CoreSkill> _coreSkillService;
        public CoreSkillsController (IElasticService<CoreSkill> coreSkillService) => _coreSkillService = coreSkillService;

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var coreSkills = await _coreSkillService.GetAsync();

            if (coreSkills.Any())
                return Ok(coreSkills);

            return NotFound();
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(string id) 
        {
            var coreSkill = await _coreSkillService.GetAsync(id);

            if (coreSkill != null)
                return Ok(coreSkill);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CoreSkill skill)
        {
            await _coreSkillService.CreateAsync(skill);
            return CreatedAtAction(nameof(Get), skill);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CoreSkill skill)
        {
            await _coreSkillService.UpdateAsync(skill);
            return Ok();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _coreSkillService.DeleteAsync(id);
            return Ok();
        }

    }
}