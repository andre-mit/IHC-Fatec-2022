using VendaCarros.Models;

namespace VendaCarros.Data.Repository.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> GetUsuarioByEmailAsync(string email);
    Task<Usuario> AddUsuario(Usuario usuario);
    Task<bool> ExistsAsync(string email);
}