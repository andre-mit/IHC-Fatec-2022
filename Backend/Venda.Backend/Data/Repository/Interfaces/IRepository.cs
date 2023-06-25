namespace Venda.Backend.Data.Repository.Interfaces;

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}