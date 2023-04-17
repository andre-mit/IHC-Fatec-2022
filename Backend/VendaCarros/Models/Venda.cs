using VendaCarros.Enums;

namespace VendaCarros.Models;

public class Venda : BaseModel
{
    public DateTime DataVenda { get; set; }
    public decimal Valor { get; set; }
    public decimal Comissao { get; set; }
    public Colaborador Vendedor { get; set; }
    public Veiculo Carro { get; set; }
    public List<Opcional> Opcionais { get; set; }

    public Venda()
    {

    }

    public Venda(DateTime dataVenda, decimal valor, decimal comissao, Colaborador vendedor, Veiculo carro, List<Opcional> opcionais)
    {
        DataVenda = dataVenda;
        Valor = valor;
        Vendedor = vendedor;
        Comissao = vendedor.Cargo == Cargo.Vendedor ? comissao : 0;
        Carro = carro;
        Opcionais = opcionais;
    }
}