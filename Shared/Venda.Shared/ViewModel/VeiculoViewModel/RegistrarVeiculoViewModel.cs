using Venda.Shared.ViewModel.OpcionalViewModel;

namespace Venda.Shared.ViewModel.VeiculoViewModel;

public class RegistrarVeiculoViewModel
{
    public string Nome { get; set; }

    public int Ano { get; set; }

    public decimal Preco { get; set; }

    public bool Disponivel { get; set; }
    public List<int> Cores { get; set; }

    public List<RegistrarOpcionalViewModel> Opcionais { get; set; }
}