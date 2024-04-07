using BlazorWasm20.InfrastructureCfDb.Repository;
using BlazorWasm20.InfrastructureCfDb.Repository.EntityRepository;
using BlazorWasm40.Application.Repository.EntityRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm20.InfrastructureCfDb
{
    public static class DependencyInjection
    {
        public  static IServiceCollection AddInfrastructureCfDb(this IServiceCollection services)
        {
            services.AddDbContext<GamesDbContext>();
            services.AddScoped<IRepositoryDeveloper, RepositoryDeveloper>();
            services.AddScoped<IRepositoryStudio, RepositoryStudio>();
            services.AddScoped<IRepositoryVideoGame, RepositoryVideoGame>();

            return services;
        }
    }
}
