using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;
using System;

namespace sogeti_portfolio_api.Controllers
{
    [Route ("consultant")]
    [ApiController]
    public class ConsultantController : AbstractController<Consultant>
    {
        public ConsultantController (IElasticService<Consultant> consultantService) : base (consultantService)
        {
            // intentionally empty
        }
    }
}