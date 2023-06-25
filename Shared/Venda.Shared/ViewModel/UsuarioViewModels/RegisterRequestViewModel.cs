using System.ComponentModel.DataAnnotations;
using Venda.Shared.Enums;
using Venda.Shared.Utils.Attributes;

namespace Venda.Shared.ViewModel.UsuarioViewModels;

public class RegisterRequestViewModel
{
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    public string Senha { get; set; }

    [Required]
    public DateOnly DataNascimento { get; set; }

    [Required]
    public Funcao Funcao { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nome { get; set; }
    [Required]
    [MaxLength(14)]
    public string Documento { get; set; }

    [Required]
    [MaxLength(14)]
    public TipoDocumento TipoDocumento { get; set; }

    [Required]
    [MaxLength(20)]
    public string Telefone { get; set; }


    [Required]
    public string Cep { get; set; }

    [Required]
    public string Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }
}