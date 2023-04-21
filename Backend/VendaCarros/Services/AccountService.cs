using VendaCarros.Data.Repository.Interfaces;
using VendaCarros.Enums;
using VendaCarros.Models;
using VendaCarros.Services.Interfaces;
using VendaCarros.Utils;

namespace VendaCarros.Services;

public class AccountService : IAccountService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AccountService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Usuario? Authenticate(string email, string senha, Funcao funcao)
    {
        var usuario = new Usuario { Email = email, Senha = senha };

        if (BCrypt.Net.BCrypt.Verify(usuario.Senha, usuario.Senha))
            return usuario;

        return null;
    }

    public async Task<Usuario> Register(Usuario usuario)
    {
        usuario.Senha = usuario.Senha!.HashPassword();
        usuario = await _usuarioRepository.AddUsuario(usuario);

        return usuario;
    }
}