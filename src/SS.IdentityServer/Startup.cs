using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SS.Application;
using SS.DAL.SqlServer;
using SS.Infrastructure;

namespace SS.IdentityServer
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication()
                .AddPersistence(Configuration)
                .AddInfrastructure();

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

            services.AddLocalApiAuthentication();
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
