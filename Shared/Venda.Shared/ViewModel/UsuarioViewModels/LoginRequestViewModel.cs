using System.ComponentModel.DataAnnotations;
using Venda.Shared.Enums;

namespace Venda.Shared.ViewModel.UsuarioViewModels;

public class LoginRequestViewModel
{
    [Required]
    public string Usuario { get; set; }
    [Required]
    public string Senha { get; set; }

    public Funcao Funcao { get; set; } = Funcao.Vendedor;
}