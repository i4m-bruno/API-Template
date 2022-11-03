using API.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mapping.CepMaps
{
    public class MunicipioMap : IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder.ToTable("Municipio");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.CodIBGE);
            builder.HasOne(x => x.Uf)
                    .WithMany(x => x.Municipios);
        }
    }
}
