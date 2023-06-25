using Microsoft.EntityFrameworkCore;
using Venda.Backend.Data;
using Venda.Backend.Data.Repository.Interfaces;
using Venda.Backend.Exceptions;
using Venda.Backend.Models;
using Venda.Shared.Enums;

namespace Venda.Backend.Data.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly VendaContext _context;
    public IUnitOfWork UnitOfWork => _context;
    public UsuarioRepository(VendaContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetUsuarioByEmailAsync(string email, Funcao funcao = Funcao.Vendedor)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Funcao == funcao);
    }

    public async Task<Usuario> AddUsuario(Usuario usuario)
    {
        var existe = await ExistsAsync(usuario.Email);

        if (existe)
            throw new DuplicateEntityException<Usuario>();

        var registered = await _context.Usuarios.AddAsync(usuario);
        return registered.Entity;
    }

    public Task<bool> ExistsAsync(string email)
    {
        return _context.Usuarios.AnyAsync(u => u.Email == email);
    }
}