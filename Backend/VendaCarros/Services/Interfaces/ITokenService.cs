using VendaCarros.Models;

namespace VendaCarros.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(Usuario usuario);
}