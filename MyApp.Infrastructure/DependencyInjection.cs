using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interface.Repository;
using MyApp.Application.Interface.Services;
using MyApp.Infrastructure.Persistence;
using MyApp.Infrastructure.Repository;
using MyApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureInjection(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthServices, JWTAuthServices>();


            return services;
        }
    }
}
