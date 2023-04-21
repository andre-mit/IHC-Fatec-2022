using Microsoft.EntityFrameworkCore;
using VendaCarros.Data.Repository.Interfaces;
using VendaCarros.Exceptions;
using VendaCarros.Models;

namespace VendaCarros.Data.Repository;

public class ColaboradorRepository : BaseRepository, IColaboradorRepository
{
    private readonly VendaContext _context;

    public ColaboradorRepository(VendaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Colaborador?> GetColaboradorByDocumentoAsync(string documento)
    {
        return await _context.Colaboradores.FirstOrDefaultAsync(u => u.Documento == documento);
    }

    public async Task<Colaborador> AddColaborador(Colaborador colaborador)
    {
        var existe = await ExistsAsync(colaborador.Documento);
        if (existe)
            throw new DuplicateEntityException<Colaborador>();
        var registered = await _context.Colaboradores.AddAsync(colaborador);
        return registered.Entity;
    }

    public async Task AddColaboradores(IEnumerable<Colaborador> colaboradores)
    {
        await _context.Colaboradores.AddRangeAsync(colaboradores);
    }

    public Task<bool> ExistsAsync(string documento)
    {
        return _context.Colaboradores.AnyAsync(u => u.Documento == documento);
    }
}