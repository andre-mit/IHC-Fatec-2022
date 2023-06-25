using Venda.Backend.Data;
using Venda.Backend.Data.Repository.Interfaces;
using Venda.Backend.Models;
using Venda.Backend.Services.Interfaces;
using Venda.Shared.ViewModel.CorViewModels;
using Venda.Shared.ViewModel.VeiculoViewModel;

namespace Venda.Backend.Services;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<List<ListaVeiculoViewModel>?> GetAll()
    {
        var veiculos = await _veiculoRepository.GetVeiculosAsync();

        return veiculos.Select(v =>
            new ListaVeiculoViewModel(v.Id, v.Nome, v.Ano, v.Preco, v.Disponivel,
                v.Cores.Select(c => new ListaCorViewModel(c.Id, c.Nome, c.RGB))
                    .ToList()))
            .ToList();
    }

    public async Task<ListaVeiculoViewModel?> GetById(int id)
    {
        var veiculo = await _veiculoRepository.GetVeiculoByIdAsync(id);
        return veiculo == null ? null : new ListaVeiculoViewModel(veiculo.Id, veiculo.Nome, veiculo.Ano, veiculo.Preco, veiculo.Disponivel,
            veiculo.Cores.Select(c => new ListaCorViewModel(c.Id, c.Nome, c.RGB))
            .ToList());
    }

    public async Task<ListaVeiculoViewModel> Create(RegistrarVeiculoViewModel model)
    {
        var cores = await _veiculoRepository.GetCoresAsync(model.Cores);

        var veiculo = new Veiculo
        {
            Nome = model.Nome,
            Ano = model.Ano,
            Preco = model.Preco,
            Disponivel = model.Disponivel,
            Opcionais = model.Opcionais.Select(o => new Opcional(o.Nome, o.Preco)).ToList(),
            Cores = cores
        };

        veiculo = await _veiculoRepository.AddVeiculoAsync(veiculo);
        await _veiculoRepository.UnitOfWork.CommitAsync();
        return new ListaVeiculoViewModel(veiculo.Id, veiculo.Nome, veiculo.Ano, veiculo.Preco, veiculo.Disponivel,
            veiculo.Cores.Select(c => new ListaCorViewModel(c.Id, c.Nome, c.RGB)).ToList());
    }

    public async Task<ListaVeiculoViewModel?> Update(AtualizarVeiculoViewModel model)
    {
        var veiculo = await _veiculoRepository.GetVeiculoByIdAsync(model.Id);

        if (veiculo == null)
            return null;

        var cores = await _veiculoRepository.GetCoresAsync(model.Cores);

        veiculo.Nome = model.Nome;
        veiculo.Ano = model.Ano;
        veiculo.Preco = model.Preco;
        veiculo.Disponivel = model.Disponivel;
        veiculo.Cores = cores;

        _veiculoRepository.UpdateVeiculoAsync(veiculo);
        await _veiculoRepository.UnitOfWork.CommitAsync();

        return new ListaVeiculoViewModel(veiculo.Id, veiculo.Nome, veiculo.Ano, veiculo.Preco, veiculo.Disponivel,
            veiculo.Cores.Select(c => new ListaCorViewModel(c.Id, c.Nome, c.RGB)).ToList());
    }

    public async Task<bool?> Delete(int id)
    {
        var veiculo = await _veiculoRepository.GetVeiculoByIdAsync(id);

        if (veiculo == null)
            return null;

        await _veiculoRepository.DeleteVeiculoAsync(veiculo.Id);
        return await _veiculoRepository.UnitOfWork.CommitAsync();
    }
}