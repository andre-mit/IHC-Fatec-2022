using Venda.Backend.Models;
using Venda.Shared.ViewModel.VeiculoViewModel;

namespace Venda.Backend.Services.Interfaces;

public interface IVeiculoService
{
    Task<List<ListaVeiculoViewModel>?> GetAll();
    Task<ListaVeiculoViewModel?> GetById(int id);
    Task<ListaVeiculoViewModel> Create(RegistrarVeiculoViewModel model);
    Task<ListaVeiculoViewModel?> Update(AtualizarVeiculoViewModel model);
    Task<bool?> Delete(int id);
}