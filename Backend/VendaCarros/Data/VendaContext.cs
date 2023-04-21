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

    public DbSet<Cor> Cores { get; set; }

    public DbSet<Opcional> Opcionais { get; set; }

    public DbSet<Veiculo> Veiculos { get; set; }

    public DbSet<Venda> Vendas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendaContext).Assembly);
    }

    /// <summary>
    /// Commit da transação assíncrona
    /// </summary>
    /// <returns></returns>
    public async Task<bool> CommitAsync()
    {
        return await SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Commit da transação
    /// </summary>
    /// <returns></returns>
    public bool Commit()
    {
        return SaveChanges() > 0;
    }

    /// <summary>
    /// Rollback da transação
    /// </summary>
    public void Rollback()
    {

    }
}