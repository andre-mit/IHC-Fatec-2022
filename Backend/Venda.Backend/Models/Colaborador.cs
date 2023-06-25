namespace Venda.Backend.Models;

public class Colaborador : Perfil
{
    public List<Venda>? Vendas { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}