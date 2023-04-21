using VendaCarros.Enums;

namespace VendaCarros.Models;

public class Colaborador : Perfil
{
    public List<Venda>? Vendas { get; set; }
}