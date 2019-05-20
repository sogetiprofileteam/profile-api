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
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace sogeti_portfolio_api.Controllers {
    [Route ("consultant")]
    [ApiController]
    public class ConsultantController : ControllerBase {

        private readonly IElasticClient _elasticClient;
        private readonly IJsonSerialization _jsonSerialize;
        private readonly IHttpClientFactory _httpClientFactory;

        public ConsultantController (IElasticClient elasticClient, IJsonSerialization jsonSerialize, IHttpClientFactory httpClientFactory) {
            _elasticClient = elasticClient;
            _jsonSerialize = jsonSerialize;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<JToken>> Get()
        {
            var client = _httpClientFactory.CreateClient("Elastic");
            var response = await client.GetStringAsync($"{client.BaseAddress}/consultant/_search?q=*");
            var jsonResponse = JObject.Parse(response);
            return jsonResponse["hits"]["hits"]
                .Select(x => x["_source"]);
        }

        [HttpGet ("{id}")]
        public async Task<JToken> Get(string id)
        {
            var client = _httpClientFactory.CreateClient("Elastic");
            var response = await client.GetStringAsync($"{client.BaseAddress}/consultant/consultant/{id}");
            var jsonResponse = JObject.Parse(response);
            return jsonResponse["_source"];
        }

        [HttpPost]
        public async Task<IIndexResponse> Post ([FromBody] Consultant consultant) {
            consultant.Id = Guid.NewGuid ();
            var response = await _elasticClient.IndexAsync (consultant, s => s.Index ("consultant").Id (consultant.Id));
            return response;
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