using VendaCarros.Data.Repository.Interfaces;
using VendaCarros.Models;
using VendaCarros.Services.Interfaces;
using VendaCarros.Utils;

namespace VendaCarros.Services;

// TODO: implementar o serviço de autenticação e registro de usuários
public class AccountService : IAccountService
{
    private readonly IColaboradorRepository _colaboradorRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public AccountService(IUsuarioRepository usuarioRepository, IColaboradorRepository colaboradorRepository)
    {
        _usuarioRepository = usuarioRepository;
        _colaboradorRepository = colaboradorRepository;
    }

    public Usuario? Authenticate(string email, string senha)
    {
        var usuario = new Usuario { Email = email, Senha = senha };

        if (usuario != null && BCrypt.Net.BCrypt.Verify(usuario.Senha, usuario.Senha))
            return usuario;
        throw new NotImplementedException();
    }

    public async Task<Usuario> Register(Usuario usuario)
    {
        usuario.Senha = usuario.Senha.HashPassword();
        usuario.Colaborador = await _colaboradorRepository.AddColaborador(usuario.Colaborador);
        usuario = await _usuarioRepository.AddUsuario(usuario);

        return usuario;
    }
}