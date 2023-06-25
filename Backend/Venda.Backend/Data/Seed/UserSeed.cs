using Venda.Backend.Models;
using Venda.Backend.Utils;
using Venda.Shared.Enums;

namespace Venda.Backend.Data.Seed;

public static class UserSeed
{
    public static Usuario Usuario => new()
    {
        Id = 1,
        Email = "diretor@carros.com",
        Funcao = Funcao.Diretor,
        Senha = "admin".HashPassword()
    };

    public static Colaborador Diretor => new()
    {
        Id = 1,
        Nome = "Diretor",
        Documento = "48042995210",
        UsuarioId = 1,
        TipoDocumento = TipoDocumento.CPF,
        DataNascimento = new DateOnly(1990, 1, 1),
        Telefone = "(11) 99999-9999"
    };
}