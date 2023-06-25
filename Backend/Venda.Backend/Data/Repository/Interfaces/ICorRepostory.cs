using Venda.Backend.Models;

namespace Venda.Backend.Data.Repository.Interfaces;

public interface ICorRepostory : IRepository
{
    Task<Cor> AddCorAsync(Cor cor);
}