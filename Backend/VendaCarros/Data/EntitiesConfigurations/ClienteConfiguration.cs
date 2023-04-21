using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaCarros.Models;

namespace VendaCarros.Data.EntitiesConfigurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Telefone).IsRequired().HasMaxLength(20);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Cep).IsRequired().HasMaxLength(10);
        builder.Property(c => c.Logradouro).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Numero).HasMaxLength(10);
        builder.Property(c => c.Complemento).HasMaxLength(100);
        builder.Property(c => c.Documento).IsRequired().HasMaxLength(20);
        builder.Property(c => c.TipoDocumento).IsRequired();

        builder
            .HasMany(c => c.Compras)
            .WithOne(v => v.Cliente);
    }
}