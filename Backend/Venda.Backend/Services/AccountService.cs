using Venda.Backend.Data.Repository.Interfaces;
using Venda.Backend.Models;
using Venda.Backend.Services.Interfaces;
using Venda.Backend.Utils;
using Venda.Shared.Enums;

namespace Venda.Backend.Services;

public class AccountService : IAccountService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IColaboradorRepository _colaboradorRepository;

    public AccountService(IUsuarioRepository usuarioRepository, IColaboradorRepository colaboradorRepository)
    {
        _usuarioRepository = usuarioRepository;
        _colaboradorRepository = colaboradorRepository;
    }

    // Todo: Implementar Perfil de Cliente
    public async Task<Usuario?> Authenticate(string email, string senha, Funcao funcao)
    {
        var perfil = await _colaboradorRepository.GetColaboradorByEmailAsync(email, funcao);

        if (perfil is not null && BCrypt.Net.BCrypt.Verify(senha, perfil.Usuario.Senha))
            return perfil.Usuario;

        return null;
    }

    public async Task<Usuario> Register(Usuario usuario)
    {
        usuario.Senha = usuario.Senha!.HashPassword();
        usuario = await _usuarioRepository.AddUsuario(usuario);

        return usuario;
    }
}