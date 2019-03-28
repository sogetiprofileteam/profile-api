using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sogeti_portfolio_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantListController : ControllerBase
    {
        /*
        //In the future we will probably need these so I am writing them now.

        --Used to interface with ConsultantRepository that will hold more functionality
        private readonly IConsultantRepository _repo;
        --Used for AutoMapper
        private readonly IMapper _mapper;
        
        public ConsultantController(IConsultantRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
         */
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
             return new string[] { "Consultant 1", "Consultant 2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Consultant " + id;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}