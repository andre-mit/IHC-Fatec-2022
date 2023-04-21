using VendaCarros.Enums;

namespace VendaCarros.Models;

public class Venda : BaseModel
{
    public DateTime DataVenda { get; set; }

    public decimal Valor { get; set; }

    public decimal Comissao { get; set; }

    public int VendedorId { get; set; }
    public Colaborador Vendedor { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public int VeiculoId { get; set; }
    public Veiculo Veiculo { get; set; }

    public List<Opcional> Opcionais { get; set; }

    public Venda()
    {

    }

    public Venda(DateTime dataVenda, decimal valor, decimal comissao, Colaborador vendedor, Veiculo veiculo, List<Opcional> opcionais)
    {
        DataVenda = dataVenda;
        Valor = valor;
        Vendedor = vendedor;
        Comissao = vendedor.Cargo == Cargo.Vendedor ? comissao : 0;
        Veiculo = veiculo;
        Opcionais = opcionais;
    }
}