using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using sogeti_portfolio_api.Extensions;
using sogeti_portfolio_api.Interfaces;
using sogeti_portfolio_api.Models;

namespace sogeti_portfolio_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("AllowSpecificOrigins",
                    builder => {
                        builder.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddScoped<IJsonSerialization, JsonSerialize>();

            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v1", new Info { Title = "DEV - Sogeti Profile API", Version = "1.0" });
            });
            services.AddElasticSearch(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowSpecificOrigins");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(swag => swag.SwaggerEndpoint("/swagger/v1/swagger.json", "DEV - Sogeti Profile API"));
            app.UseMvc();
        }
    }
}
