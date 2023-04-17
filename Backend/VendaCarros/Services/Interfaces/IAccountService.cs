using VendaCarros.Models;

namespace VendaCarros.Services.Interfaces;

public interface IAccountService
{
    Usuario Authenticate(string nomeUsuario, string senha);
    void Register(Usuario usuario);
}