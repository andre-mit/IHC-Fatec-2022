﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaCarros.Enums;
using VendaCarros.Services.Interfaces;
using VendaCarros.ViewModel.UsuarioViewModels;

namespace VendaCarros.Controllers;

// Todo: Implementar o controller de usuários (autenticação e cadastro)
[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;

    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;

    public UsuarioController(ILogger<UsuarioController> logger, IAccountService accountService, ITokenService tokenService)
    {
        _logger = logger;
        _accountService = accountService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var usuario = _accountService.Authenticate(model.Usuario, model.Senha);
            if (usuario is null)
            {
                _logger.LogInformation("Usuário autenticado com sucesso");
                return Unauthorized();
            }

            var token = _tokenService.GenerateToken(usuario);
            var response = new LoginResponseViewModel(usuario.Email, usuario.Funcao, token);

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar logar");
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = nameof(Funcao.Colaborador))]
    [Authorize(Roles = $"{nameof(Cargo.Gerente)},{nameof(Cargo.Diretor)}")]
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

    [Authorize(Roles = nameof(Funcao.Colaborador))]
    [Authorize(Roles = nameof(Cargo.Diretor))]
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