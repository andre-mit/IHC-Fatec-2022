using VendaCarros.Enums;

namespace VendaCarros.Models;

public class Colaborador : BaseModel
{
    public string Nome { get; set; }
    public string Documento { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
    public Cargo Cargo { get; set; }
    public List<Venda>? Vendas { get; set; }
}