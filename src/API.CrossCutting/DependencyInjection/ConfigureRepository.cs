using API.Data.Context;
using API.Data.Repository;
using API.Domain.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection service)
        {
            service.AddDbContext<MyContext>( options =>
                options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;pwd=bruno-9211"));

            service.AddScoped(typeof (IRepository<>), typeof (BaseRepository<>));
        }
    }
}
