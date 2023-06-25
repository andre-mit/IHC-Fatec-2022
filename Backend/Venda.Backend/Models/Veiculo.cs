namespace Venda.Backend.Models;

public class Veiculo : BaseModel
{
    public string Nome { get; set; }

    public int Ano { get; set; }

    public decimal Preco { get; set; }

    public bool Disponivel { get; set; }

    public List<Cor> Cores { get; set; }

    public List<Venda> Vendas { get; set; }

    public List<Opcional> Opcionais { get; set; }

    public Veiculo()
    {

    }

    public Veiculo(string nome, int ano, decimal preco, bool disponivel)
    {
        Nome = nome;
        Ano = ano;
        Preco = preco;
        Disponivel = disponivel;
    }
}