using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sogeti_portfolio_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        // GET api/skills
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "skill1", "skill2" };
        }

        // GET api/skills/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "skill";
        }

        // POST api/skills
        [HttpPost]
        public void Post([FromBody] string skill)
        {
        }

        // PUT api/skills/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string skill)
        {
        }

        // DELETE api/skills/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}