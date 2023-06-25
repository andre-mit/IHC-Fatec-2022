using Venda.Backend.Models;
using Venda.Shared.ViewModel.UsuarioViewModels;

namespace Venda.Backend.Extensions.ViewModelExtensions;

public static class UserExtensions
{
    public static Usuario ToUsuario(this RegisterRequestViewModel model)
    {
        return new Usuario
        {
            Email = model.Email,
            Funcao = model.Funcao,
            Senha = model.Senha
        };
    }   
}