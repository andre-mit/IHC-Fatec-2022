using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Venda.Backend.Models;

namespace Venda.Backend.Data.EntitiesConfigurations;

public class CorConfiguration : IEntityTypeConfiguration<Cor>
{
    public void Configure(EntityTypeBuilder<Cor> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        builder.Property(c => c.RGB).IsRequired().HasMaxLength(6);

        builder
            .HasMany(c => c.Veiculos)
            .WithMany(v => v.Cores);
    }
}