using Massenger.Core.Common;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using Massenger.Infra.Common;
using Massenger.Infra.Repository;
using Massenger.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_API
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
            services.AddControllers();
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IMass_PostRepository, Mass_PostRepository>();
            services.AddScoped<IMass_PostService, Mass_PostService>();
            services.AddScoped<IMass_UsersRepository, Mass_UsersRepository>();
            services.AddScoped<IMass_MessageRepository, Mass_MessageRepository>();
            services.AddScoped<IMass_UsersService, Mass_UsersService>();
            services.AddScoped<IMass_MessageService, Mass_MessageService>();
            services.AddScoped<IMass_PostService, Mass_PostService>();
            services.AddScoped<IMass_MessageService, Mass_MessageService>();
            services.AddScoped<IMass_ContryRepository, Mass_ContryRepository>();
            services.AddScoped<IMass_ContryService, Mass_ContryService>(); 
            services.AddScoped<IJwtRepository, JwtRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailservice, emailclass>();
            services.AddScoped<IMass_ServiceRepository, Mass_ServiceRepository>();
            services.AddScoped<IMass_ServiceService, Mass_ServiceService>(); 

                     services.AddScoped<IMass_ContactRepository, Mass_ContactRepository>();
            services.AddScoped<IMass_ContactService, Mass_ContactService>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

          ).AddJwtBearer(y =>
          {
              y.RequireHttpsMetadata = false;
              y.SaveToken = true;
              y.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[Saja Key -this should very long ]")),
                  ValidateIssuer = false,
                  ValidateAudience = false,

              };


          });
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
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
