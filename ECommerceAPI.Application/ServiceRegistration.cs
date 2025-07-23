using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using ECommerceAPI.Application.Behaviors;

namespace ECommerceAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(options => { options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
