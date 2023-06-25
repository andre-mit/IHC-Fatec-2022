using Venda.Backend.Services.Helpers;

namespace Venda.Backend.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(UsuarioToken usuario);
}