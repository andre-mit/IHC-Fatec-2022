using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaCarros.Models;

namespace VendaCarros.Utils;

public static class PerfilConfigurationExtensions
{
    public static void ConfigurePerfil<T>(this EntityTypeBuilder<T> builder) where T : Perfil
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Telefone).IsRequired().HasMaxLength(20);
        builder.Property(c => c.Documento).IsRequired().HasMaxLength(20);
        builder.Property(c => c.TipoDocumento).IsRequired();
        builder.Property(c => c.DataNascimento).IsRequired();

        builder.HasOne(x => x.Usuario);
    }
}