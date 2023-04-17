using Microsoft.EntityFrameworkCore;
using VendaCarros.Models;

namespace VendaCarros.Data;

public class VendaContext : DbContext, IUnitOfWork
{
    public VendaContext(DbContextOptions<VendaContext> options) : base(options)
    { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Colaborador> Colaboradores { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Modelo> Modelos { get; set; }
    public DbSet<Opcional> Opcionais { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Venda> Vendas { get; set; }

    public async Task<bool> CommitAsync()
    {
        var sucesso = await SaveChangesAsync() > 0;

        return sucesso;
    }

    public bool Commit()
    {
        var sucesso = SaveChanges() > 0;

        return sucesso;
    }

    public void Rollback()
    {
        
    }
}