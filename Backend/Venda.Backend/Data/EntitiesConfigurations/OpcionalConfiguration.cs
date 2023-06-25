using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Venda.Backend.Models;

namespace Venda.Backend.Data.EntitiesConfigurations;

public class OpcionalConfiguration : IEntityTypeConfiguration<Opcional>
{
    public void Configure(EntityTypeBuilder<Opcional> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Nome).IsRequired().HasMaxLength(100);
        builder.Property(o => o.Preco).IsRequired();

        builder
            .HasMany(o => o.Vendas)
            .WithMany(v => v.Opcionais);
    }
}