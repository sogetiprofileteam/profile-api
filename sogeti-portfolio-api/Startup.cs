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
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.OpenApi.Models;
using sogeti_portfolio_api.Data;

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
            services.AddMvc(options => options.EnableEndpointRouting =false)
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            
            services.AddScoped<IJsonSerialization, JsonSerialize>();
            services.AddTransient<UserService>();
            services.AddTransient<ConsultantService>();
            services.AddTransient<CoreSkillService>();
            services.AddTransient<TechnicalSkillService>();
            services.AddTransient<EducationService>();
            services.AddTransient<CertificationService>();
            services.AddTransient<UserRepository>();
            services.AddTransient<ConsultantRepository>();
            services.AddTransient<CoreSkillsRepository>();
            services.AddTransient<TechnicalSkillsRepository>();
            services.AddTransient<EducationRepository>();
            services.AddTransient<CertificationRepository>();

            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v1", new OpenApiInfo { Title = "DEV - Sogeti Profile API"});
            });

            var elasticAuth = ASCIIEncoding.ASCII.GetBytes(Configuration["sqlserver:auth"]);
            services.AddHttpClient("sqlserver", c =>
            {
                c.BaseAddress = new Uri(Configuration["sqlserver:url"]);
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(elasticAuth));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
