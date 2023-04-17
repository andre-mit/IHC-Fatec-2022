namespace VendaCarros.Data.Repository;

public abstract class BaseRepository
{
    private readonly VendaContext _context;

    protected BaseRepository(VendaContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;
}