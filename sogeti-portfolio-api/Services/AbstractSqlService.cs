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
   public class AbstractSqlService<T> : ISqlService<T> where T : AbstractModel
   {
      private readonly IHttpClientFactory _httpClientFactory;
      protected string Path;
      protected AbstractSqlService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

      public async Task CreateAsync(HttpContent element)
      {
         HttpClient client = _httpClientFactory.CreateClient(HttpClients.SqlClient);
         //element = Guid.NewGuid();
         var response = await client.PutAsync($"{client.BaseAddress}{Path}/_doc/{element}", element);
         response.EnsureSuccessStatusCode();
      }

      public async Task DeleteAsync(string id)
      {
         var client = _httpClientFactory.CreateClient(HttpClients.SqlClient);
         var response = await client.DeleteAsync($"{client.BaseAddress}{Path}/_doc/{id}");
         response.EnsureSuccessStatusCode();
      }

      public async Task<IEnumerable<JToken>> GetAsync()
      {
         var client = _httpClientFactory.CreateClient(HttpClients.SqlClient);
         var response = await client.GetStringAsync($"{client.BaseAddress}{Path}/_search?q=*&size=500");
         var jsonResponse = JObject.Parse(response);

         return jsonResponse["hits"]["hits"]
            .Select(x => x["_source"]);
      }

      public async Task<JToken> GetAsync(string id)
      {
         var client = _httpClientFactory.CreateClient(HttpClients.SqlClient);
         var response = await client.GetStringAsync($"{client.BaseAddress}{Path}/_doc/{id}");
         var jsonResponse = JObject.Parse(response);
            
         if (jsonResponse["found"].Value<bool>())
            return jsonResponse["_source"];

         return null;
      }

      public async Task UpdateAsync(HttpContent element)
      {
         var client = _httpClientFactory.CreateClient(HttpClients.SqlClient);
         var response = await client.PutAsync($"{client.BaseAddress}{Path}/_doc/{element}", element);
         response.EnsureSuccessStatusCode();
      }
   }
}
