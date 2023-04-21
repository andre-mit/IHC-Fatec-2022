using VendaCarros.Enums;
using VendaCarros.Models;

namespace VendaCarros.Services.Interfaces;

public interface IAccountService
{
    Task<Usuario?> Authenticate(string email, string senha, Funcao funcao);
    Task<Usuario> Register(Usuario usuario);
}