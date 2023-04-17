using Microsoft.EntityFrameworkCore;
using VendaCarros.Data.Repository.Interfaces;
using VendaCarros.Exceptions;
using VendaCarros.Models;

namespace VendaCarros.Data.Repository;

public class UsuarioRepository : BaseRepository, IUsuarioRepository
{
    private readonly VendaContext _context;

    public UsuarioRepository(VendaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetUsuarioByEmailAsync(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
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