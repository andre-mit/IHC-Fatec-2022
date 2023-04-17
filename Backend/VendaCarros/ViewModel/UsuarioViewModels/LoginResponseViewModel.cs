using VendaCarros.Enums;

namespace VendaCarros.ViewModel.UsuarioViewModels;

public class LoginResponseViewModel
{
    public string Usuario { get; set; }
    public Funcao Funcao { get; set; }
    public string Token { get; set; }

    public LoginResponseViewModel(string usuario, Funcao funcao, string token)
    {
        Usuario = usuario;
        Funcao = funcao;
        Token = token;
    }
}