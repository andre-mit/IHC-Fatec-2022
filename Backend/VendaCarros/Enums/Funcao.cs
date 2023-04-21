using System.ComponentModel;

namespace VendaCarros.Enums;

public enum Funcao : byte
{
    [Description(nameof(Cliente))]
    Cliente,
    [Description(nameof(Vendedor))]
    Vendedor,
    [Description(nameof(Gerente))]
    Gerente,
    [Description(nameof(Diretor))]
    Diretor
}