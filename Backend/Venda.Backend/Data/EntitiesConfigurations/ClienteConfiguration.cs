using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Venda.Backend.Models;
using Venda.Backend.Utils;

namespace Venda.Backend.Data.EntitiesConfigurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ConfigurePerfil();

        builder.Property(c => c.Logradouro).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Numero).HasMaxLength(10);
        builder.Property(c => c.Complemento).HasMaxLength(100);

        builder
            .HasMany(c => c.Compras)
            .WithOne(v => v.Cliente)
            .OnDelete(DeleteBehavior.Cascade);

        //builder
        //    .HasOne(x => x.Usuario)
        //    .WithMany(x => x.Clientes)
        //    .OnDelete(DeleteBehavior.Cascade);

        builder.UseTpcMappingStrategy();
    }
}