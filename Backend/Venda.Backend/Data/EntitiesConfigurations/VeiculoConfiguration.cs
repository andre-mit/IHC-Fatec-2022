using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Venda.Backend.Models;

namespace Venda.Backend.Data.EntitiesConfigurations;

public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Nome).IsRequired().HasMaxLength(100);
        builder.Property(v => v.Ano).IsRequired();
        builder.Property(v => v.Preco).IsRequired();
        builder.Property(v => v.Disponivel).IsRequired();

        builder
            .HasMany(v => v.Cores)
            .WithMany(c => c.Veiculos);

        builder
            .HasMany(v => v.Vendas)
            .WithOne(v => v.Veiculo)
            .HasForeignKey(v => v.VeiculoId);

        builder
            .HasMany(v => v.Opcionais)
            .WithOne(o => o.Veiculo);
    }
}