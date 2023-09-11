using System;
using CodeChallenge.Data.Contexts;
using CodeChallenge.Data.Helpers;
using CodeChallenge.Models.Constants;
using CodeChallenge.Repositories;
using CodeChallenge.Repositories.IRepositories;
using CodeChallenge.Services;
using CodeChallenge.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeChallenge.Config
{
    public class App
    {


        public WebApplication Configure(string[] args)
        {
            args ??= Array.Empty<string>();

            var builder = WebApplication.CreateBuilder(args);

            builder.UseEmployeeDB();
            
            AddServices(builder.Services);

            var app = builder.Build();

            var env = builder.Environment;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedEmployeeDB();
            }

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }

        private void AddServices(IServiceCollection services)
        {

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRespository>();
            services.AddScoped<ICompensationEmployeeRepository, CompensationEmployeeRespository>();

            services.AddControllers();
        }

        private void SeedEmployeeDB()
        {
            new EmployeeDataSeeder(
                new EmployeeContext(
                    new DbContextOptionsBuilder<EmployeeContext>().UseInMemoryDatabase(CONFIG_CONSTANTS.DB_NAME).Options
            )).Seed().Wait();

            new CompensationEmployeeContext(
                    new DbContextOptionsBuilder<CompensationEmployeeContext>().UseInMemoryDatabase(CONFIG_CONSTANTS.COMPENSATION_DB_NAME).Options
            );
        }
    }
}
