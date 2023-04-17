namespace VendaCarros.ViewModel.UsuarioViewModels;

public class LoginResponseViewModel
{
    public string Usuario { get; set; }
    public string Funcao { get; set; }
    public string Token { get; set; }

    public LoginResponseViewModel(string usuario, string funcao, string token)
    {
        Usuario = usuario;
        Funcao = funcao;
        Token = token;
    }
}