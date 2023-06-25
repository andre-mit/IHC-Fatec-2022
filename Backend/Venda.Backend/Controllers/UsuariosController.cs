using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Venda.Backend.Extensions.ViewModelExtensions;
using Venda.Backend.Services.Helpers;
using Venda.Backend.Services.Interfaces;
using Venda.Shared.Enums;
using Venda.Shared.ViewModel.UsuarioViewModels;

namespace Venda.Backend.Controllers;

// Todo: Implementar o controller de usuários (autenticação e cadastro)
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : Controller
{
    private readonly ILogger<UsuariosController> _logger;

    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;

    public UsuariosController(ILogger<UsuariosController> logger, IAccountService accountService, ITokenService tokenService)
    {
        _logger = logger;
        _accountService = accountService;
        _tokenService = tokenService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var usuario = await _accountService.Authenticate(model.Usuario, model.Senha, model.Funcao);
            if (usuario is null)
            {
                _logger.LogTrace("Usuário não autenticado");
                return Unauthorized();
            }

            var usuarioToken = new UsuarioToken(usuario, usuario.Funcao);
            var token = _tokenService.GenerateToken(usuarioToken);
            var response = new LoginResponseViewModel(usuario.Email, usuario.Funcao, token);

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar logar");
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = $"{nameof(Funcao.Gerente)},{nameof(Funcao.Diretor)}")]
    [HttpPost("cadastrar/vendedor")]
    public IActionResult CadastrarVendedor([FromBody] RegisterRequestViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            _accountService.Register(model.ToUsuario());
            _logger.LogInformation("Usuário registrado com sucesso");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao registrar usuário");
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = nameof(Funcao.Diretor))]
    [HttpPost("cadastrar/gerente")]
    public IActionResult CadastrarGerente([FromBody] RegisterRequestViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            _accountService.Register(model.ToUsuario());
            _logger.LogInformation("Usuário registrado com sucesso");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao registrar usuário");
            return BadRequest(ex.Message);
        }
    }
}