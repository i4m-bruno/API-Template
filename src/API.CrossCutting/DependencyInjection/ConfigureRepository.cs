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
            service.AddDbContext<MyContext>( options =>
                options.UseSqlServer("Server=BRUNO_PC\\BRUNO_SQLEXPRESS;Database=dbApi;User Id=sa;Password=bruno-9211;"));

            service.AddScoped(typeof (IRepository<>), typeof (BaseRepository<>));
            service.AddScoped<IUserRepository, UserImplementation>();
        }
    }
}
