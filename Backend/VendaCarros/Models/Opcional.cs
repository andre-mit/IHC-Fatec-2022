namespace VendaCarros.Models;

public class Opcional : BaseModel
{
    public string Name { get; set; }
    public decimal Preco { get; set; }
    public Veiculo Carro { get; set; }
    public List<Venda> Vendas { get; set; }

    public Opcional()
    {
        
    }

    public Opcional(string name, decimal preco, Veiculo carro)
    {
        Name = name;
        Preco = preco;
        Carro = carro;
    }
}