using Venda.Backend.Models;
using Venda.Shared.Enums;

namespace Venda.Backend.Data.Repository.Interfaces;

public interface IUsuarioRepository : IRepository
{
    Task<Usuario?> GetUsuarioByEmailAsync(string email, Funcao funcao = Funcao.Vendedor);
    Task<Usuario> AddUsuario(Usuario usuario);
    Task<bool> ExistsAsync(string email);
}