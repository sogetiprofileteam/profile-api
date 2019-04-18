using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Elasticsearch;
using Elasticsearch.Net;
using Nest;

namespace sogeti_portfolio_api.Extensions {
    public static class ElasticsearchExtenstions {
        public static void AddElasticSearch (this IServiceCollection services, IConfiguration configuration) {
            var url = configuration["elasticsearch:url"];
            var defaultIndex = configuration["elasticsearch:index"];

            var settings = new ConnectionSettings(new Uri(url))
            .DefaultIndex(defaultIndex);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}