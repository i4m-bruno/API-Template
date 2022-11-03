using System;
using API.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mapping.CepMaps
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("CEP");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Cep);
            builder.HasOne(x => x.Municipio)
                    .WithMany(x => x.Ceps);
        }
    }
}
