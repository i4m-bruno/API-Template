using System;
using API.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
            
        }
    }

    public class DbTeste : IDisposable
    {
        private string dbName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-",String.Empty)}";
        public ServiceProvider serviceProvider {get; private set;}

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<MyContext>(o =>
                o.UseSqlServer($"Server=BRUNO_PC\\BRUNO_SQLEXPRESS;Database={dbName};User Id=sa;Password=bruno-9211;"),
                ServiceLifetime.Transient
            );

            serviceProvider = serviceCollection.BuildServiceProvider();
            
            using (var context = serviceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = serviceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
