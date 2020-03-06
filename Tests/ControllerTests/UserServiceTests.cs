using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Controllers;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.Interfaces;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Services;
using Xunit;

namespace Tests.ControllerTests
{
   public class UserServiceTests
   {
      [Fact]
      public void TestSqLite() {
         // UserService service = new UserService(IRepository repo, IMapper map);
         
         // var returnValue = service.GetUsers();
         
         // Debug.WriteLine(returnValue);
      }
   }
}
