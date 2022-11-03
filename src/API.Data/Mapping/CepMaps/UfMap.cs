using API.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mapping.CepMaps
{
    public class UfMap : IEntityTypeConfiguration<UfEntity>
    {
        public void Configure(EntityTypeBuilder<UfEntity> builder)
        {
            builder.ToTable("UF");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Sigla)
                    .IsUnique();
        }
    }
}
