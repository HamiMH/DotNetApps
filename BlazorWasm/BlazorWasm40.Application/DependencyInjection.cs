using BlazorWasm40.Application.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm40.Application
{
    public static class DependencyInjection
    {
        public  static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IIteratorFormating,IteratorFormating>();
            return services;
        }
    }
}
