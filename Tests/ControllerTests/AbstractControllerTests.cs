using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Controllers;
using sogeti_portfolio_api.Interfaces;
using sogeti_portfolio_api.Models;
using Xunit;

namespace Tests.ControllerTests
{
   public class TestModel : AbstractModel
   {
      // intentionally empty
   }

   public class TestController : AbstractController<TestModel>
   {
      public TestController(IElasticService<TestModel> service) : base(service)
      {
         // intentionally empty
      }
   }
   
   public class AbstractControllerTests
   {
      [Fact(DisplayName = "Get() should return 404 if elements not found")]
      public async Task Fact1()
      {
         // arrange
         IElasticService<TestModel> service = Mock.Of<IElasticService<TestModel>>();
         // all mocked methods return null by default
         
         TestController controller = new TestController(service);

         // act
         IActionResult result = await controller.Get();
         
         // assert
         Assert.NotNull(result);
         Assert.IsAssignableFrom<NotFoundResult>(result);
      }   
      
      [Fact(DisplayName = "Get() should return 200 if elements are found")]
      public async Task Fact2()
      {
         // arrange
         IElasticService<TestModel> service = Mock.Of<IElasticService<TestModel>>();
         IEnumerable<JToken> returnList = new List<JToken>()
         {
            new JObject()
         };
         
         Mock.Get(service)
            .Setup(p => p.GetAsync())
            .Returns(Task.FromResult(returnList));
         
         TestController controller = new TestController(service);

         // act
         IActionResult result = await controller.Get();
         
         // assert
         Assert.NotNull(result);
         Assert.IsAssignableFrom<OkObjectResult>(result);
      }   
   }
}
