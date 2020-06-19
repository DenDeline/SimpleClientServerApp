using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<IUwaDbContext, UwaDbContext>(options =>
            {
                //options.UseSqlServer("Data Source=localhost;Database=DELETEMEPLEASEIAMSOTERRIBLE;User Id=sa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", 
                //    opt => opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));

                options.UseInMemoryDatabase("Memory");
            });

            return services;
        }
    }
}
