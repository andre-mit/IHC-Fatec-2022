using VendaCarros.Enums;

namespace VendaCarros.Models;

public class Cliente : Perfil
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }

    public List<Venda> Compras { get; set; }
}