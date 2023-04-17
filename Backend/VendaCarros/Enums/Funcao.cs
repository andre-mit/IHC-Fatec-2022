using System.ComponentModel;

namespace VendaCarros.Enums;

public enum Funcao : byte
{
    [Description(nameof(Colaborador))]
    Colaborador,
    [Description(nameof(Cliente))]
    Cliente
}