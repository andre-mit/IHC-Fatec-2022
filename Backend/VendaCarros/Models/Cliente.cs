using VendaCarros.Enums;

namespace VendaCarros.Models;

public class Cliente : BaseModel
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string Documento { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
    public List<Venda> Compras { get; set; }

    public Cliente()
    {
        
    }

    
}