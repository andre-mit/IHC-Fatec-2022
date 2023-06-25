using System.ComponentModel.DataAnnotations.Schema;
using Venda.Shared.Enums;

namespace Venda.Backend.Models;

public class Usuario : BaseModel
{
    public string Email { get; set; }

    public string? Senha { get; set; }

    public Funcao Funcao { get; set; }

    public Colaborador Colaborador { get; set; }
    //public List<Cliente> Clientes { get; set; }
}