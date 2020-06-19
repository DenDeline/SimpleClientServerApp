using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SS.IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var identityServerBuilder = services.AddIdentityServer();
            if (Environment.IsDevelopment())
            {
                identityServerBuilder
                    .AddInMemoryClients(Config.Clients())
                    .AddInMemoryApiScopes(Config.ApiScopes())
                    .AddInMemoryApiResources(Config.ApiResources())
                    .AddInMemoryIdentityResources(Config.IdentityResources());

                identityServerBuilder.AddDeveloperSigningCredential();
            }

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
