using System;
using API.Data.Mapping;
using API.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Context
{
    public class MyContext: DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            SeedUser(modelBuilder);
        }

        protected void SeedUser(ModelBuilder builder)
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
        }
    }
}
