using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers
{
    [Route ("education")]
    [ApiController]
    public class EducationController : AbstractController<School>  {

        public EducationController (IElasticService<School> educationService) : base(educationService)
        {
            // intentionally empty
        }
    }
}