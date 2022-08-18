using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talabat.API.Errors;
using Talabat.API.Extentions;
using Talabat.API.Helpers;
using Talabat.API.Middlewares;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Repositories;
using Talabat.DAL;
using Talabat.DAL.Identity;

namespace Talabat.API
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

            services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddSingleton<IConnectionMultiplexer>(S =>
            {
                var connection = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"));

                return ConnectionMultiplexer.Connect(connection);
            });
            services.AddDbContext<AppIdentityDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));

            });

            services.AddSwaggerServices();
            services.AddApplicationServices();
            services.AddIdentityervices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddelwares>();
            if (env.IsDevelopment())
            {
                app.UseSwaggerServices();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                _=endpoints.MapControllers();
            });
        }
    }
}
