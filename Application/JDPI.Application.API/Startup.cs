using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using JDPI.Common.Util;
using JDPI.Platform.Util.Providers;
using JDPI.Common.Util.Providers;
using JDPI.Platform.Service.Interfaces;
using JDPI.Platform.Service;
using JDPI.Platform.Business.Interfaces;
using JDPI.Platform.Entity;
using JDPI.Platform.Business;
using JDPI.Platform.Repository.Interfaces;
using JDPI.Platform.Repository;

namespace JDPI.Application.API
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserBUS<User>, UserBUS>();
            services.AddScoped<IUserDAO<User>, UserDAO<User>>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JDPI.Application.API", Version = "v1" });
            });

            services.AddMvc();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            
            services.AddSingleton<IConfigProvider>(new ConfigProvider(){
                DbName = configuration.GetSection("DbSettings")["DbName"].ToString(),
                DbUrl = configuration.GetSection("DbSettings")["DbUrl"].ToString(),
                DbUsername = configuration.GetSection("DbSettings")["DbUsername"].ToString(),
                DbPwd = configuration.GetSection("DbSettings")["DbPwd"].ToString(),
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JDPI.Application.API v1"));
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