using Microsoft.EntityFrameworkCore;
using VendaCarros.Enums;

namespace VendaCarros.Models;

[Keyless]
public abstract class Perfil
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public string Telefone { get; set; }

    public string Documento { get; set; }
    public TipoDocumento TipoDocumento { get; set; }

    public DateOnly DataNascimento { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}