using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Interfaces;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Controllers
{
   public class AbstractController<T> : ControllerBase where T : AbstractModel
   {
      private readonly IService<T> _service;

      protected AbstractController(IService<T> service)
      {
         _service = service;
      }

      [HttpGet]
      public async Task<IActionResult> Get() 
      {
         IEnumerable<JToken> elements = await _service.GetAsync();

         if (elements.Any())
            return Ok(elements);

         return NotFound();
      }

      [HttpGet ("{id}")]
      public async Task<IActionResult> Get(string id) 
      {
         JToken elements = await _service.GetAsync(id);

         if (elements != null)
            return Ok(elements);

         return NotFound();
      }

      [HttpPost]
      public async Task<IActionResult> Post(HttpContent element)
      {
         await _service.CreateAsync(element);
         return CreatedAtAction(nameof(Get), element);
      }

      [HttpPut]
      public async Task<IActionResult> Put(HttpContent element)
      {
         await _service.UpdateAsync(element);
         return Ok();
      }

      [HttpDelete ("{id}")]
      public async Task<IActionResult> Delete(string id)
      {
         await _service.DeleteAsync(id);
         return Ok();
      }
   }
}
