using VendaCarros.Models;

namespace VendaCarros.Services.Interfaces;

public interface IAccountService
{
    Usuario? Authenticate(string email, string senha);
    Task<Usuario> Register(Usuario usuario);
}