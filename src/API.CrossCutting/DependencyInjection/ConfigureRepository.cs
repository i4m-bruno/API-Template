using System;
using API.Data.Context;
using API.Data.Implementations;
using API.Data.Repository;
using API.Domain.interfaces;
using API.Domain.repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection service)
        {
            if(Environment.GetEnvironmentVariable("DATABASE").ToLower() == "sqlserver")
            {
                service.AddDbContext<MyContext>( options =>
                    options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CON")));
            } else {
                service.AddDbContext<MyContext>( options =>
                    options.UseMySql(Environment.GetEnvironmentVariable("DB_CON")));
            }

            service.AddScoped(typeof (IRepository<>), typeof (BaseRepository<>));
            service.AddScoped<IUserRepository, UserImplementation>();
        }
    }
}
