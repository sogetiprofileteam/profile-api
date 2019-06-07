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
   public class AbstractElasticService<T> : IElasticService<T> where T : AbstractModel
   {
      private readonly IHttpClientFactory _httpClientFactory;
      protected string Path;
      protected AbstractElasticService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

      public async Task CreateAsync(T element)
      {
         HttpClient client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
         element.id = Guid.NewGuid();
         var response = await client.PostAsJsonAsync($"{client.BaseAddress}/{Path}/_doc/{element.id}", element);
         response.EnsureSuccessStatusCode();
      }

      public async Task DeleteAsync(string id)
      {
         var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
         var response = await client.DeleteAsync($"{client.BaseAddress}/{Path}/_doc/{id}");
         response.EnsureSuccessStatusCode();
      }

      public async Task<IEnumerable<JToken>> GetAsync()
      {
         var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
         var response = await client.GetStringAsync($"{client.BaseAddress}/{Path}/_search?q=*");
         var jsonResponse = JObject.Parse(response);

         return jsonResponse["hits"]["hits"]
            .Select(x => x["_source"]);
      }

      public async Task<JToken> GetAsync(string id)
      {
         var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
         var response = await client.GetStringAsync($"{client.BaseAddress}/{Path}/_doc/{id}");
         var jsonResponse = JObject.Parse(response);
            
         if (jsonResponse["found"].Value<bool>())
            return jsonResponse["_source"];

         return null;
      }

      public async Task UpdateAsync(T element)
      {
         var client = _httpClientFactory.CreateClient(HttpClients.ElasticClient);
         var response = await client.PutAsJsonAsync($"{client.BaseAddress}/{Path}/_doc/{element.id}", element);
         response.EnsureSuccessStatusCode();
      }
   }
}
