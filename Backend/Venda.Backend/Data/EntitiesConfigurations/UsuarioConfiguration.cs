using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Venda.Backend.Data.Seed;
using Venda.Backend.Models;

namespace Venda.Backend.Data.EntitiesConfigurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Senha).IsRequired(false);

        builder.HasData(UserSeed.Usuario);
    }
}