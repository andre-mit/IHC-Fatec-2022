using VendaCarros.Enums;

namespace VendaCarros.Models;

public class Usuario : BaseModel
{
    public string Email { get; set; }
    public string Senha { get; set; }

    public Colaborador Colaborador { get; set; }

    public Funcao Funcao { get; set; }
}