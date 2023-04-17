using VendaCarros.Models;
using VendaCarros.Services.Interfaces;

namespace VendaCarros.Services;

// TODO: implementar o serviço de autenticação e registro de usuários
public class AccountService : IAccountService
{
    public Usuario Authenticate(string nomeUsuario, string senha)
    {
        var usuario = new Usuario { NomeUsuario = nomeUsuario, Senha = senha };

        if (usuario != null && BCrypt.Net.BCrypt.Verify(usuario.Senha, usuario.Senha))
            return usuario;
        throw new NotImplementedException();
    }

    public void Register(Usuario usuario)
    {
        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
        throw new NotImplementedException();
    }
}