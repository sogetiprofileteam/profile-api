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

namespace sogeti_portfolio_api.Controllers {
    [Route ("technicalskills")]
    [ApiController]
    public class TechnicalSkillsController : ControllerBase {

        private readonly IElasticClient _elasticClient;
        private readonly IJsonSerialization _jsonSerialize;

        public TechnicalSkillsController (IElasticClient elasticClient, IJsonSerialization jsonSerialize) {
            _elasticClient = elasticClient;
            _jsonSerialize = jsonSerialize;
        }

        [HttpGet]
        public async Task<string> Get () {
            var response = await _elasticClient.SearchAsync<TechnicalSkill> (s => s.Index ("technicalskills"));
            var json = _jsonSerialize.Serialize(response.Documents);
            return json;
        }

        [HttpGet ("{id}")]
        public async Task<string> Get (string id) {
            var response = await _elasticClient.SearchAsync<TechnicalSkill> (s => s
                .Index ("technicalskills")
                .Query (q => q
                    .Match (m => m
                        .Field (f => f.Id)
                        .Query (id))));
            var json = _jsonSerialize.Serialize(response.Documents);
            return json;
        }

        [HttpPost]
        public async Task<IIndexResponse> Post ([FromBody] TechnicalSkill skill) {
            skill.Id = Guid.NewGuid ();
            var response = await _elasticClient.IndexAsync (skill, s => s.Index ("technicalskills").Id (skill.Id));
            return response;
        }

        [HttpPut]
        public async Task<IIndexResponse> Put ([FromBody] TechnicalSkill skill) {
            var response = await _elasticClient.IndexAsync (skill, s => s.Index ("technicalskills").Id (skill.Id));
            return response;
        }

        // DELETE consultant/5
        [HttpDelete ("{id}")]
        public async Task<IDeleteResponse> Delete (string id) {
            var response = await _elasticClient.DeleteAsync<TechnicalSkill> (id, d => d.Index ("technicalskills"));
            return response;
        }

    }
}