using System.ComponentModel;

namespace Venda.Shared.Enums;

public enum Funcao : byte
{
    [Description(nameof(Vendedor))]
    Vendedor,
    [Description(nameof(Gerente))]
    Gerente,
    [Description(nameof(Diretor))]
    Diretor
    //[Description(nameof(Cliente))]
    //Cliente
}