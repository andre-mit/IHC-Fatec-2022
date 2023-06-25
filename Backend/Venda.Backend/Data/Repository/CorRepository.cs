using Venda.Backend.Data.Repository.Interfaces;
using Venda.Backend.Models;

namespace Venda.Backend.Data.Repository;

public class CorRepository : ICorRepostory
{
    private readonly VendaContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public CorRepository(VendaContext context)
    {
        _context = context;
    }

    public async Task<Cor> AddCorAsync(Cor cor)
    {
        var registered = await _context.Cores.AddAsync(cor);
        return registered.Entity;
    }
}