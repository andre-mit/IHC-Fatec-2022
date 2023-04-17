namespace VendaCarros.Models;

public class Carro : BaseModel
{
    public int Ano { get; set; }
    public string Cor { get; set; }
    public decimal Preco { get; set; }
    public bool Disponivel { get; set; }
    public Modelo Modelo { get; set; }
    public List<Venda> Vendas { get; set; }

    public Carro()
    {

    }

    public Carro(int ano, string cor, decimal preco, bool disponivel, Modelo modelo)
    {
        Ano = ano;
        Cor = cor;
        Preco = preco;
        Disponivel = disponivel;
        Modelo = modelo;
    }
}