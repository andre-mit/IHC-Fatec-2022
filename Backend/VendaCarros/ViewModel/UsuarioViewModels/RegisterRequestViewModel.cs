using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VendaCarros.Enums;
using VendaCarros.Models;
using VendaCarros.Utils.Attributes;

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


    [ConditionalRequired(nameof(Funcao), Funcao.Cliente)]
    public string Cep { get; set; }

    [ConditionalRequired(nameof(Funcao), Funcao.Cliente)]
    public string Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public Usuario ToUsuario()
    {
        return new Usuario
        {
            Email = Email,
            Senha = Senha,
            Funcao = Funcao
        };
    }

    public Colaborador ToColaborador()
    {
        return new Colaborador
        {
            Nome = Nome,
            Documento = Documento,
            Telefone = Telefone,
            DataNascimento = DataNascimento,
            TipoDocumento = TipoDocumento,
            Usuario = ToUsuario()
        };
    }

    public Cliente ToCliente()
    {
        return new Cliente
        {
            Nome = Nome,
            Documento = Documento,
            Telefone = Telefone,
            Cep = Cep,
            Logradouro = Logradouro,
            Numero = Numero,
            Complemento = Complemento,
            DataNascimento = DataNascimento,
            TipoDocumento = TipoDocumento,
            Usuario = ToUsuario()
        };
    }
}