using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers {
    [Route ("certification")]
    [ApiController]
    public class CertificationController : AbstractController<Certification>  {

        public CertificationController (ISqlService<Certification> certificationService)
        : base(certificationService)
        {
            // intentionally empty
        }

    }
}