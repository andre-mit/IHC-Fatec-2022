using VendaCarros.Models;

namespace VendaCarros.Data.Repository.Interfaces;

public interface IColaboradorRepository
{
    Task<Colaborador?> GetColaboradorByDocumentoAsync(string documento);
    Task<Colaborador> AddColaborador(Colaborador colaborador);
    Task AddColaboradores(IEnumerable<Colaborador> colaboradores);
    Task<bool> ExistsAsync(string email);
}