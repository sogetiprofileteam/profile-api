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
        private readonly IJsonSerialization _serializer;

        public ConsultantService(IHttpClientFactory httpClientFactory, IJsonSerialization serializer) 
        {
            _httpClientFactory = httpClientFactory;
            _serializer = serializer;
        }

        public async Task CreateAsync(Consultant consultant)
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            consultant.Id = Guid.NewGuid();
            var response = await client.PostAsJsonAsync($"{client.BaseAddress}/consultant/_doc/{consultant.Id}", consultant);
            response.EnsureSuccessStatusCode();
        }

        public async Task<string> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            var response = await client.GetStringAsync($"{client.BaseAddress}/consultant/_doc/{id}");
            var jsonResponse = JObject.Parse(response);
            
            if (jsonResponse["found"].Value<bool>())
            {
                return _serializer.SerializeWithCamelCaseProperties(jsonResponse["_source"]);
            }

            return null;
        }

        public async Task<IEnumerable<string>> GetAsync()
        {
            var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
            var response = await client.GetStringAsync($"{client.BaseAddress}/consultant/_search?q=*");
            var jsonResponse = JObject.Parse(response);

            return jsonResponse["hits"]["hits"]
                .Select(x => _serializer.SerializeWithCamelCaseProperties(x["_source"]));
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
            var response = await client.PutAsJsonAsync($"{client.BaseAddress}/consultant/_doc/{consultant.Id}", consultant);
            response.EnsureSuccessStatusCode();
        }
    }
}