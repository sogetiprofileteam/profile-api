using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;
using sogeti_portfolio_api.Services;
using System.Net;

namespace sogeti_portfolio_api.Controllers {
    [Route ("consultant")]
    [ApiController]
    public class ConsultantController : ControllerBase {

        private readonly IElasticClient _elasticClient;
        private readonly IJsonSerialization _jsonSerialize;
        private readonly ConsultantService _service;

        public ConsultantController (IElasticClient elasticClient, IJsonSerialization jsonSerialize, ConsultantService service) {
            _elasticClient = elasticClient;
            _jsonSerialize = jsonSerialize;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consultants = await _service.GetConsultantsAsync();
            return Ok(consultants);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(string id) 
        {
            var response = await _service.GetConsultantAsync(id);

            if (response.StatusCode != HttpStatusCode.OK)
                return NotFound();

            return Ok(response.Resource);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Consultant consultant) 
        {
            var response = await _service.PostConsultantAsync(consultant);
            if (response.StatusCode == HttpStatusCode.Created)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        public async Task<IIndexResponse> Put ([FromBody] Consultant consultant) {
            Console.WriteLine(consultant);
            var response = await _elasticClient.IndexAsync (consultant, s => s.Index ("consultant").Id (consultant.Id));
            return response;
        }

        // DELETE consultant/5
        [HttpDelete ("{id}")]
        public async Task<IDeleteResponse> Delete (string id) {
            var response = await _elasticClient.DeleteAsync<Consultant> (id, d => d.Index ("consultant"));
            return response;
        }

    }
}