using Venda.Backend.Models;

namespace Venda.Backend.Data.Repository.Interfaces;

public interface IVeiculoRepository : IRepository
{
    Task<List<Veiculo>> GetVeiculosAsync();
    Task<Veiculo?> GetVeiculoByIdAsync(int id);
    Task<Veiculo> AddVeiculoAsync(Veiculo veiculo);
    Veiculo UpdateVeiculoAsync(Veiculo veiculo);
    Task DeleteVeiculoAsync(int id);
    Task<List<Cor>> GetCoresAsync(List<int> cores);
}