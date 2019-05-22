using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers {
    [Route ("technicalskills")]
    [ApiController]
    public class TechnicalSkillsController : ControllerBase {

        private readonly IElasticService<TechnicalSkill> _technicalSkillService;
        public TechnicalSkillsController (IElasticService<TechnicalSkill> technicalSkillService) => _technicalSkillService = technicalSkillService;

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var technicalSkills = await _technicalSkillService.GetAsync();

            if (technicalSkills.Any())
                return Ok(technicalSkills);

            return NotFound();
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(string id) 
        {
            var technicalSkill = await _technicalSkillService.GetAsync(id);

            if (technicalSkill != null)
                return Ok(technicalSkill);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(TechnicalSkill skill)
        {
            await _technicalSkillService.CreateAsync(skill);
            return CreatedAtAction(nameof(Get), skill);
        }

        [HttpPut]
        public async Task<IActionResult> Put(TechnicalSkill skill)
        {
            await _technicalSkillService.UpdateAsync(skill);
            return Ok();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _technicalSkillService.DeleteAsync(id);
            return Ok();
        }

    }
}