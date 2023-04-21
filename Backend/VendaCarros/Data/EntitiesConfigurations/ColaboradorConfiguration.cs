using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaCarros.Data.Seed;
using VendaCarros.Models;
using VendaCarros.Utils;

namespace VendaCarros.Data.EntitiesConfigurations;

public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
{
    public void Configure(EntityTypeBuilder<Colaborador> builder)
    {
        builder.ConfigurePerfil();

        builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Documento).IsRequired().HasMaxLength(11);

        builder
            .HasOne(x => x.Usuario)
            .WithMany(x=>x.Colaboradores)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(c => c.Vendas)
            .WithOne(v => v.Vendedor)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.UseTpcMappingStrategy();

        builder.HasData(UserSeed.Diretor);
    }
}