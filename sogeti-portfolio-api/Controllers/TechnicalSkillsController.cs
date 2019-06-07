using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers {
    [Route ("technicalskills")]
    [ApiController]
    public class TechnicalSkillsController : AbstractController<TechnicalSkill> {
        public TechnicalSkillsController (IElasticService<TechnicalSkill> technicalSkillService)
        : base(technicalSkillService)
        {
            // intentionally empty
        }
    }
}