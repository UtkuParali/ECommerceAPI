using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Infrastructure.Persistence.Contexts;
using ECommerceAPI.Infrastructure.Repositories;
using ECommerceAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ECommerceDb;Trusted_Connection=True;"));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
