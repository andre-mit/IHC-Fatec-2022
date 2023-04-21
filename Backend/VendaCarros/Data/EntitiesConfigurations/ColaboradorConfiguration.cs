using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaCarros.Models;

namespace VendaCarros.Data.EntitiesConfigurations;

public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
{
    public void Configure(EntityTypeBuilder<Colaborador> builder)
    {
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Documento).IsRequired().HasMaxLength(11);
        builder.Property(x => x.Cargo).IsRequired();
    }
}