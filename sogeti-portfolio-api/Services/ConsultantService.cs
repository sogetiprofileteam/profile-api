using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using sogeti_portfolio_api.Interfaces;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class ConsultantService : IElasticService<Consultant>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ConsultantService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;
        
        public async Task CreateAsync(Consultant consultant)
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            consultant.id = Guid.NewGuid();
            var response = await client.PostAsJsonAsync($"{client.BaseAddress}/consultant/_doc/{consultant.id}", consultant);
            response.EnsureSuccessStatusCode();
        }

        public async Task<JToken> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            var response = await client.GetStringAsync($"{client.BaseAddress}/consultant/_doc/{id}");
            var jsonResponse = JObject.Parse(response);
            
            if (jsonResponse["found"].Value<bool>())
            {
                return jsonResponse["_source"];
            }

            return null;
        }

        public async Task<IEnumerable<JToken>> GetAsync()
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            var response = await client.GetStringAsync($"{client.BaseAddress}/consultant/_search?q=*");
            var jsonResponse = JObject.Parse(response);

            return jsonResponse["hits"]["hits"]
                .Select(x => x["_source"]);
        }

        public async Task DeleteAsync(string id)
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            var response = await client.DeleteAsync($"{client.BaseAddress}/consultant/_doc/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(Consultant consultant)
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            var response = await client.PutAsJsonAsync($"{client.BaseAddress}/consultant/_doc/{consultant.id}", consultant);
            response.EnsureSuccessStatusCode();
        }
    }
}