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

namespace sogeti_portfolio_api.Controllers {
    [Route ("user")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IElasticClient _elasticClient;

        public UserController (IElasticClient elasticClient) {
            _elasticClient = elasticClient;
        }

        [HttpGet]
        public async Task<string> Get () {
            var response = await _elasticClient.SearchAsync<User> (s => s.Index ("user"));
            var json = JsonConvert.SerializeObject (response.Documents, Formatting.Indented);
            return json;
        }

        [HttpGet ("{id}")]
        public async Task<string> Get (string id) {
            var response = await _elasticClient.SearchAsync<User> (s => s
                .Index ("user")
                .Query (q => q
                    .Match (m => m
                        .Field (f => f.Id)
                        .Query (id))));
            var json = JsonConvert.SerializeObject (response.Documents, Formatting.Indented);
            return json;
        }

        [HttpPost]
        public async Task<IIndexResponse> Post ([FromBody] User user) {
            user.Id = Guid.NewGuid ();
            var response = await _elasticClient.IndexAsync (user, s => s.Index ("user").Id (user.Id));
            return response;
        }

        // DELETE consultant/5
        [HttpDelete ("{id}")]
        public async Task<IDeleteResponse> Delete (string id) {
            var response = await _elasticClient.DeleteAsync<User> (id, d => d.Index ("user"));
            return response;
        }

    }
}