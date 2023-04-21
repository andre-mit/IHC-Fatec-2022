namespace VendaCarros.Models;

public class Cor : BaseModel
{
    public string Nome { get; set; }
    public List<Veiculo> Veiculos { get; set; }

    public Cor()
    {
    }

    public Cor(string nome)
    {
        Nome = nome;
    }
}