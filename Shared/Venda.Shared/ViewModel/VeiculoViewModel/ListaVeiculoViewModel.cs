using Venda.Shared.ViewModel.CorViewModels;

namespace Venda.Shared.ViewModel.VeiculoViewModel;

public class ListaVeiculoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public int Ano { get; set; }

    public decimal Preco { get; set; }

    public bool Disponivel { get; set; }
    public List<ListaCorViewModel> Cores { get; set; }

    public ListaVeiculoViewModel()
    {
        
    }

    public ListaVeiculoViewModel(int id, string nome, int ano, decimal preco, bool disponivel, List<ListaCorViewModel> cores)
    {
        Id = id;
        Nome = nome;
        Ano = ano;
        Preco = preco;
        Disponivel = disponivel;
        Cores = cores;
    }
}