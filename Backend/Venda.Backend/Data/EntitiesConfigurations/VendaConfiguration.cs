using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Venda.Backend.Data.EntitiesConfigurations;

public class VendaConfiguration : IEntityTypeConfiguration<Models.Venda>
{
    public void Configure(EntityTypeBuilder<Models.Venda> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.DataVenda).IsRequired();

        builder.Property(v => v.Valor).IsRequired();

        builder
            .HasOne(v => v.Vendedor)
            .WithMany(v => v.Vendas)
            .HasForeignKey(v => v.VendedorId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder
            .HasOne(v => v.Veiculo)
            .WithMany(v => v.Vendas)
            .HasForeignKey(v => v.VeiculoId);

        builder
            .HasMany(v => v.Opcionais)
            .WithMany(vo => vo.Vendas);
    }
}