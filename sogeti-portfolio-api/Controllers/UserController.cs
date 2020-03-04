using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers {
    [Route ("user")]
    [ApiController]
    public class UserController : AbstractController<User>  {

        public UserController (IService<User> userService)
        : base(userService)
        {
            // intentionally empty
        }

    }
}