using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Interfaces;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class CoreSkillService : IElasticService<CoreSkill>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CoreSkillService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public async Task CreateAsync(CoreSkill skill)
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            skill.Id = Guid.NewGuid();
            var response = await client.PostAsJsonAsync($"{client.BaseAddress}/coreskill/_doc/{skill.Id}", skill);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string id)
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            var response = await client.DeleteAsync($"{client.BaseAddress}/coreskill/_doc/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<JToken>> GetAsync()
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            var response = await client.GetStringAsync($"{client.BaseAddress}/coreskill/_search?q=*");
            var jsonResponse = JObject.Parse(response);

            return jsonResponse["hits"]["hits"]
                .Select(x => x["_source"]);
        }

        public async Task<JToken> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            var response = await client.GetStringAsync($"{client.BaseAddress}/coreskill/_doc/{id}");
            var jsonResponse = JObject.Parse(response);
            
            if (jsonResponse["found"].Value<bool>())
                return jsonResponse["_source"];

            return null;
        }

        public async Task UpdateAsync(CoreSkill skill)
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            var response = await client.PutAsJsonAsync($"{client.BaseAddress}/coreskill/_doc/{skill.Id}", skill);
            response.EnsureSuccessStatusCode();
        }
    }
}