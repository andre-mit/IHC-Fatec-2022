using Microsoft.EntityFrameworkCore;
using Venda.Backend.Data.Repository.Interfaces;
using Venda.Backend.Models;

namespace Venda.Backend.Data.Repository;

public class VeiculoRepository : IVeiculoRepository
{
    private VendaContext _context;
    public IUnitOfWork UnitOfWork => _context;
    public VeiculoRepository(VendaContext context)
    {
        _context = context;
    }

    public Task<List<Veiculo>> GetVeiculosAsync()
    {
        return _context.Veiculos.ToListAsync();
    }

    public async Task<Veiculo?> GetVeiculoByIdAsync(int id)
    {
        return await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Veiculo> AddVeiculoAsync(Veiculo veiculo)
    {
        var registered = await _context.Veiculos.AddAsync(veiculo);
        return registered.Entity;
    }

    public Veiculo UpdateVeiculoAsync(Veiculo veiculo)
    {
        var updated = _context.Veiculos.Update(veiculo);
        return updated.Entity;
    }

    public async Task DeleteVeiculoAsync(int id)
    {
        var veiculo = await GetVeiculoByIdAsync(id) ?? throw new Exception();
        _context.Veiculos.Remove(veiculo);
    }

    public async Task<List<Cor>> GetCoresAsync(List<int> cores)
    {
        return await _context.Cores.Where(c => cores.Contains(c.Id)).ToListAsync();
    }
}