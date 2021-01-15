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
using JDPI.Common.Util;
using JDPI.Platform.Util.Providers;

namespace JDPI.Application.API
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceCollection services)
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
