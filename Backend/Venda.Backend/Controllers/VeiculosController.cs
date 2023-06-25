using Microsoft.AspNetCore.Mvc;
using Venda.Backend.Services.Interfaces;
using Venda.Shared.ViewModel.VeiculoViewModel;

namespace Venda.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeiculosController : Controller
{
    private readonly IVeiculoService _veiculoService;

    public VeiculosController(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var veiculos = await _veiculoService.GetAll();
        return Ok(veiculos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var veiculo = await _veiculoService.GetById(id);

        if (veiculo == null)
            return NotFound();

        return Ok(veiculo);
    }

    [HttpPost]
    public async Task<IActionResult> Registrar([FromBody] RegistrarVeiculoViewModel model)
    {
        var veiculo = await _veiculoService.Create(model);
        return Ok(veiculo);
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarVeiculoViewModel model)
    {
        var veiculo = await _veiculoService.Update(model);
        return Ok(veiculo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var result = await _veiculoService.Delete(id);

        if(!result.HasValue)
            return NotFound("Veículo não encontrado");

        if (result.Value)
            return NoContent();

        return BadRequest();
    }
}