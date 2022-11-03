using System;
using API.Data.Mapping;
using API.Data.Mapping.CepMaps;
using API.Data.Seeds;
using API.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Context
{
    public class MyContext: DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UfEntity> Uf { get; set; }
        public DbSet<MunicipioEntity> Municipio { get; set; }
        public DbSet<CepEntity> Cep { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureMaps(modelBuilder);
            Seeds(modelBuilder);
        }

        protected void Seeds(ModelBuilder builder)
        {
            builder.Entity<UserEntity>().HasData
            (
                new UserEntity{
                    Id = Guid.NewGuid(),
                    Email = "adm@mail",
                    Nome = "BrunoAdm",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                }
            );

            UfSeed.Ufs(builder);
        }

        protected void ConfigureMaps(ModelBuilder builder)
        {
            builder.Entity<UserEntity>(new UserMap().Configure);
            builder.Entity<UfEntity>(new UfMap().Configure);
            builder.Entity<CepEntity>(new CepMap().Configure);
            builder.Entity<MunicipioEntity>(new MunicipioMap().Configure);
        }
    }
}
