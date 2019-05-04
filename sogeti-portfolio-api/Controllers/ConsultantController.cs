using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;
using sogeti_portfolio_api.Data;
using sogeti_portfolio_api.Domain;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Controllers {
    [Route ("consultant")]
    [ApiController]
    public class ConsultantController : ControllerBase {

        private readonly IElasticClient _elasticClient;
        private readonly IJsonSerialization _jsonSerialize;

        public ConsultantController (IElasticClient elasticClient, IJsonSerialization jsonSerialize) {
            _elasticClient = elasticClient;
            _jsonSerialize = jsonSerialize;
        }


        [HttpGet]
        public async Task<string> Get () {
            var response = await _elasticClient.SearchAsync<Consultant> (s => s.Index ("consultant"));
            var json = _jsonSerialize.Serialize(response.Documents);
            return json;
        }

        [HttpGet ("{id}")]
        public async Task<string> Get (string id) {
            var response = await _elasticClient.SearchAsync<Consultant> (s => s
                .Index ("consultant")
                .Query (q => q
                    .Match (m => m
                        .Field (f => f.Id)
                        .Query (id))));
            var json = _jsonSerialize.Serialize(response.Documents);
            return json;
        }

        [HttpPost]
        public async Task<IIndexResponse> Post ([FromBody] Consultant consultant) {
            consultant.Id = Guid.NewGuid ();
            var response = await _elasticClient.IndexAsync (consultant, s => s.Index ("consultant").Id (consultant.Id));
            return response;
        }

        [HttpPut]
        public async Task<IIndexResponse> Put ([FromBody] Consultant consultant) {
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