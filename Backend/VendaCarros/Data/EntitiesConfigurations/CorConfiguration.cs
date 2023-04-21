using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaCarros.Models;

namespace VendaCarros.Data.EntitiesConfigurations;

public class CorConfiguration : IEntityTypeConfiguration<Cor>
{
    public void Configure(EntityTypeBuilder<Cor> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);

        builder
            .HasMany(c => c.Veiculos)
            .WithMany(v => v.Cores);
    }
}