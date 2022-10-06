using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Criar migrações
            // var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;pwd=bruno-9211";
            var connectionString = "Server=BRUNO_PC\\BRUNO_SQLEXPRESS;Database=dbApi;User Id=sa;Password=bruno-9211;";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            // optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
