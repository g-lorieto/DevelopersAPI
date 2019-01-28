using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopersApi.Core.Services;
using DevelopersApi.Core.Interfaces.Generics;
using DevelopersApi.DataAccess.DataSources;
using DevelopersApi.Core.Interfaces;
using DevelopersApi.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using DevelopersApi.Core.Settings;

namespace DevelopersApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Developers API", Version = "v1" });
            });

            services.AddHttpClient();

            services.AddTransient<IDevelopersService, DevelopersService>();
            services.AddTransient<IAsyncService<Developer>, GenericService>();
            services.AddSingleton<IDataSource, JSONDataSource>();

            var settings = Configuration.GetSection("ApplicationSettings").GetChildren();

            services.AddSingleton<AppSettingsModel>(new AppSettingsModel
            {
                JSONFIle = Configuration.GetSection("ApplicationSettings:JSONFile").Value,
                BaseAddress = Configuration.GetSection("ApplicationSettings:BaseAddress").Value,
                GetAllServiceEndpoint = Configuration.GetSection("ApplicationSettings:GetAllServiceEndpoint").Value
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevelopersAPI V1");
            });
        }
    }
}

