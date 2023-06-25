using Venda.Backend.Models;
using Venda.Shared.Enums;

namespace Venda.Backend.Services.Interfaces;

public interface IAccountService
{
    Task<Usuario?> Authenticate(string email, string senha, Funcao funcao);
    Task<Usuario> Register(Usuario usuario);
}