using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers
{
    [Route ("coreskills")]
    [ApiController]
    public class CoreSkillsController : AbstractController<CoreSkill> {

        public CoreSkillsController(IElasticService<CoreSkill> coreSkillService) : base(coreSkillService)
        {
            // intentionally empty
        }
    }
}
