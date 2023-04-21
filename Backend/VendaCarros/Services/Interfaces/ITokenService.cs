using VendaCarros.Services.Helpers;

namespace VendaCarros.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(UsuarioToken usuario);
}