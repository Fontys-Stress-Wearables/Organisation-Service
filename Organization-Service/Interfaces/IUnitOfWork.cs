using Organization_Service.Interfaces;

namespace Organization_Service.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IOrganizationRepository Organizations { get; }
    int Complete();
}