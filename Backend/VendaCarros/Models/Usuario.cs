using System.ComponentModel.DataAnnotations.Schema;
using VendaCarros.Enums;

namespace VendaCarros.Models;

public class Usuario : BaseModel
{
    public string Email { get; set; }

    public string? Senha { get; set; }

    public Funcao Funcao { get; set; }
    
    public List<Colaborador> Colaboradores { get; set; }
    public List<Cliente> Clientes { get; set; }
}