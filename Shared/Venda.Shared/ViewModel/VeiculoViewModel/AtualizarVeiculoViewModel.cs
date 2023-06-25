namespace Venda.Shared.ViewModel.VeiculoViewModel;

public class AtualizarVeiculoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public int Ano { get; set; }

    public decimal Preco { get; set; }

    public bool Disponivel { get; set; }
    public List<int> Cores { get; set; }
}