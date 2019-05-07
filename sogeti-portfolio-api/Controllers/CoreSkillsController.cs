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
    [Route ("coreskills")]
    [ApiController]
    public class CoreSkillsController : ControllerBase {

        private readonly IElasticClient _elasticClient;
        private readonly IJsonSerialization _jsonSerialize;

        public CoreSkillsController (IElasticClient elasticClient, IJsonSerialization jsonSerialize) {
            _elasticClient = elasticClient;
            _jsonSerialize = jsonSerialize;
        }

        [HttpGet]
        public async Task<string> Get () {
            var response = await _elasticClient.SearchAsync<CoreSkill> (s => s.Index ("coreskills"));
            var json = _jsonSerialize.Serialize(response.Documents);
            return json;
        }

        [HttpGet ("{id}")]
        public async Task<string> Get (string id) {
            var response = await _elasticClient.SearchAsync<CoreSkill> (s => s
                .Index ("coreskills")
                .Query (q => q
                    .Match (m => m
                        .Field (f => f.Id)
                        .Query (id))));
            var json = _jsonSerialize.Serialize(response.Documents);
            return json;
        }

        [HttpPost]
        public async Task<IIndexResponse> Post ([FromBody] CoreSkill skill) {
            skill.Id = Guid.NewGuid ();
            var response = await _elasticClient.IndexAsync (skill, s => s.Index ("coreskills").Id (skill.Id));
            return response;
        }

        [HttpPut]
        public async Task<IIndexResponse> Put ([FromBody] string skill) {
            var coreSkill = JsonConvert.DeserializeObject<CoreSkill>(skill);
            var response = await _elasticClient.IndexAsync (coreSkill, s => s.Index ("coreskills").Id (coreSkill.Id));
            return response;
        }

        // DELETE consultant/5
        [HttpDelete ("{id}")]
        public async Task<IDeleteResponse> Delete (string id) {
            var response = await _elasticClient.DeleteAsync<CoreSkill> (id, d => d.Index ("coreskills"));
            return response;
        }

    }
}