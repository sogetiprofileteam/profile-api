using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using sogeti_portfolio_api.Interfaces;
using sogeti_portfolio_api.Models;
using System.Text;
using System.Net.Http.Headers;
using sogeti_portfolio_api.Services;

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
            services.AddTransient<IElasticService<Consultant>, ConsultantService>();
            services.AddTransient<IElasticService<CoreSkill>, CoreSkillService>();
            services.AddTransient<IElasticService<TechnicalSkill>, TechnicalSkillService>();

            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v1", new Info { Title = "DEV - Sogeti Profile API", Version = "1.0" });
            });

            var elasticAuth = ASCIIEncoding.ASCII.GetBytes(Configuration["elasticsearch:auth"]);
            services.AddHttpClient("Elastic", c =>
            {
                c.BaseAddress = new Uri(Configuration["elasticsearch:url"]);
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(elasticAuth));
            });
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
