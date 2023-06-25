namespace Venda.Backend.Models;

public class Opcional : BaseModel
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public Veiculo Veiculo { get; set; }

    public List<Venda> Vendas { get; set; }

    public Opcional()
    {

    }

    public Opcional(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
}