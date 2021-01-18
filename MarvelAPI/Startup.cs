using MarvelAPI.Controllers;
using MarvelAPIService.GetData;
using MarvelAPIService.Marvel;
using MarvelAPIService.Model;
using MarvelAPIService.Services;
using MarvelStorage.DataHandler;
using MarvelStorage.Storage;
using MarvelStorage.StorageHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelAPI
{
    public class Startup
    {
        [Obsolete]
        public Startup(IConfiguration configuration, Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            Configuration = configuration;
            var settingPath = Path.GetFullPath(Path.Combine(@"../MarvelLibs/marvelapisettings.json"));
            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile(settingPath, optional: true, reloadOnChange: true);

            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().AddMvcOptions(options =>
            {
                options.EnableEndpointRouting = false;
            });
            services.AddSingleton<IMarvelService, MarvelService>();
            services.AddSingleton<IMarvelDataHandler, MarvelDataHandler>();
            services.AddSingleton<IMarvelDataContainer, MarvelDataContainer>();
            services.AddSingleton<IDataHandler, DataHandler>();
            services.AddSingleton<IFileStorage, FileStorage>();
            services.Configure<API_KEYS>(Configuration.GetSection("API_KEYS"))
                .AddSingleton(sp => sp.GetRequiredService<IOptions<API_KEYS>>().Value); ;
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            
        }
    }
}
