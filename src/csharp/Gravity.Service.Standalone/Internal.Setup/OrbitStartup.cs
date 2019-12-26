/*
 * CHANGE LOG
 * 
 * 2019-01-19
 *    - modify: improve XML comments
 */
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Gravity.Services.Standalone.Internal.Setup
{
    internal class OrbitStartup
    {
        public OrbitStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// this method gets called by the runtime. use this method to add services to the container
        /// </summary>
        /// <param name="services">services controller</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(o =>
            {
                o.SerializerSettings.Formatting = Formatting.Indented;
                o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddLogging();
        }

        /// <summary>
        /// this method gets called by the runtime. use this method to configure the HTTP request pipeline
        /// </summary>
        /// <param name="app">application builder</param>
        /// <param name="env">hosting environment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}