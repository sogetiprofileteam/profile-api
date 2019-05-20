using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Configuration;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api.Services
{
    public class ConsultantService
    {
        private readonly DocumentClient cosmosDbClient;

        public ConsultantService()
        {
            // todo: goes to config
            var endpoint = "https://profile-db.documents.azure.com:443/";
            var key = "RxMmKsMdnUkgK9tapHWUgPwiE4T49jSfcoOeihhSP7QgGIgecA9H6gbj3LoP4M9SpqUkvMQLH0dSVpJD8V1hhA==";
            cosmosDbClient = new DocumentClient(new Uri(endpoint), key);
        }

        public async Task<IEnumerable<dynamic>> GetConsultantsAsync()
        {
            var documents = await cosmosDbClient.ReadDocumentFeedAsync(UriFactory.CreateDocumentCollectionUri("profileDatabase", "profiles"));
            return documents.AsEnumerable();
        }

        public async Task<ResourceResponse<Document>> GetConsultantAsync(string id)
        {
            try
            {
                //var options = new RequestOptions { PartitionKey = new PartitionKey("/Practice") };
                return await cosmosDbClient.ReadDocumentAsync(UriFactory.CreateDocumentUri("profileDatabase", "profiles", id));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ResourceResponse<Document>> PostConsultantAsync(Consultant consultant)
        {
            return await cosmosDbClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("profileDatabase", "profiles"), consultant);
        }
        
    }
}