using System.ComponentModel.DataAnnotations;
using VendaCarros.Enums;
using VendaCarros.Models;

namespace VendaCarros.ViewModel.UsuarioViewModels;

public class RegisterRequestViewModel
{
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    public string Senha { get; set; }

    [Required]
    public Funcao Funcao { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nome { get; set; }
    [Required]
    [MaxLength(14)]
    public string Documento { get; set; }
    public Cargo Cargo { get; set; }

    public Usuario ToUsuario()
    {
        return new Usuario
        {
            Email = Email,
            Senha = Senha,
            Funcao = Funcao,
            Colaboradores = ToColaborador()
        };
    }

    public Colaborador ToColaborador()
    {
        return new Colaborador
        {
            Nome = Nome,
            Documento = Documento,
            Cargo = Cargo
        };
    }
}