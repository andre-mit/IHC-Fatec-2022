using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaCarros.Data.Seed;
using VendaCarros.Models;

namespace VendaCarros.Data.EntitiesConfigurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Senha).IsRequired(false);

        builder.HasData(UserSeed.Usuario);
    }
}