﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VendaCarros.Enums;
using VendaCarros.Options;
using VendaCarros.Services.Helpers;
using VendaCarros.Services.Interfaces;

namespace VendaCarros.Services;

public class TokenService : ITokenService
{
    private readonly AuthOptions _authOptions;

    public TokenService(IOptions<AuthOptions> authOptions)
    {
        _authOptions = authOptions.Value;
    }

    public string GenerateToken(UsuarioToken usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_authOptions.TokenSecret);
        var claims = new ClaimsIdentity(new Claim[]
        {
            new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new(ClaimTypes.Name, usuario.Email),
            new(ClaimTypes.Role, usuario.Funcao.ToString())
        });

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            Expires = DateTime.UtcNow.AddHours(9),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}