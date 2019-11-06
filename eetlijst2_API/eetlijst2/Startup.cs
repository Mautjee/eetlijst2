using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
//using eetlijst2.Helpers;
using Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;

namespace eetlijst2
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
            // Je voegt de database toe (de context)
            services.AddDbContext<mauro_sqlContext>(options =>
            {
  

                switch (Configuration.GetSection("DatabaseConfiguration").GetChildren().FirstOrDefault(d => d.Key.Equals("Provider")).Value)
                {
                    case "inmemory":
                        // in memory
                        options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                        break;
                    case "sqlserver":
                        // via sqlserver
                        options.UseSqlServer(Configuration.GetSection("DatabaseConfiguration").GetChildren().FirstOrDefault(d => d.Key.Equals("ConnectionString")).Value);
                        break;
                    default:
                        break;
                }
            });

            // Je voegt de services toe aan de services collectie voor dependency injection
            // Je mapt eigenlijk de interfaces tegen de implementaties aan. (om het net te doen)
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountLogic, AccountLogic>();



            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
