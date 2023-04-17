using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VendaCarros.Models;
using VendaCarros.Options;
using VendaCarros.Services.Interfaces;

namespace VendaCarros.Services;

public class TokenService : ITokenService
{
    private readonly AuthOptions _authOptions;

    public TokenService(AuthOptions authOptions)
    {
        _authOptions = authOptions;
    }

    public string GenerateToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_authOptions.TokenSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new(ClaimTypes.Name, usuario.Email),
                new(ClaimTypes.Role, usuario.Funcao)
            }),
            Expires = DateTime.UtcNow.AddHours(9),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}