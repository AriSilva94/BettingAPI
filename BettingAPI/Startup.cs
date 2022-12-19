using AutoMapper;
using BettingAPI.Infrastructure.Data.Query.MapperProfiles.v1;
using BettingAPI.Infrastructure.Service.Interfaces;
using BettingAPI.Infrastructure.Service.ServiceHandler.Championship;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace BettingAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IChampionshipApiService), typeof(ChampionshipApiServiceClient));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BettingAPI", Version = "v1" });
            });

            services.AddHttpClient("base-url", client =>
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Configuration.GetSection("Auth:authorization-bearer").Value);
                client.BaseAddress = new Uri(Configuration.GetSection("Urls:championship").Value);
            });

            services
                .AddSingleton(provider => new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ChampionshipQueryResponse());

                }).CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BettingAPI v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
