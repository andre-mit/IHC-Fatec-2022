namespace Venda.Backend.Data;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
    bool Commit();
    void Rollback();
}