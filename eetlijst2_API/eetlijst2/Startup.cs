using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using eetlijst2.Services;
using eetlijst2.Services.Interfaces;
//using eetlijst2.Helpers;
using Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Model;

namespace eetlijst2
{
    public class Startup
    { 

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();

            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddOptions();

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
                        break; }
            });
            
            
            //Authentication
            services.Configure<JwtConfiguration>(Configuration.GetSection(nameof(JwtConfiguration)));

            services.AddDistributedMemoryCache();
            
            services.AddSession();
            
            
            
            var jwtConfig = new JwtConfiguration();
            Configuration.GetSection(nameof(JwtConfiguration)).Bind(jwtConfig);

            services.AddAuthentication(auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(token =>
                {
                    token.RequireHttpsMetadata = !Environment.IsDevelopment();
                    token.SaveToken = true;
                
                    token.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.SecretKey)),
                        ValidateIssuer = true,
                        ValidIssuer = jwtConfig.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtConfig.Issuer,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            
            // Je voegt de services toe aan de services collectie voor dependency injection
            // Je mapt eigenlijk de interfaces tegen de implementaties aan. (om het net te doen)

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountLogic, AccountLogic>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IStudenthouseLogic, StudenthouseLogic>();
            services.AddTransient<IStudenthouseContext, StudenthouseRepository>();
            
            
            
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
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();
            
            app.Use(async (context, next) =>
            {
                var JWToken = context.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }
                await next();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
