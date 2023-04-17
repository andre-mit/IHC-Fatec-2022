using System.ComponentModel.DataAnnotations;

namespace VendaCarros.ViewModel.UsuarioViewModels;

public class LoginRequestViewModel
{
    [Required]
    public string Usuario { get; set; }
    [Required]
    public string Senha { get; set; }
}