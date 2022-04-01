using Organization_Service.Interfaces;

namespace Organization_Service.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
        Organizations = new OrganizationRepository(_context);
    }

    public IOrganizationRepository Organizations { get; }

    public void Dispose()
    {
        _context.Dispose();
    }
    
    public int Complete()
    {
        return _context.SaveChanges();
    }
}