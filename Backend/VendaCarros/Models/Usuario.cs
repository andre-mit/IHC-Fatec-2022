using VendaCarros.Enums;

namespace VendaCarros.Models;

public class Usuario : BaseModel
{
    public string NomeUsuario { get; set; }
    public string Senha { get; set; }

    private Funcao _funcao;

    public string Funcao
    {
        get => Enum.GetName(_funcao) ?? string.Empty;
        set => _funcao = Enum.Parse<Funcao>(value);
    }

}