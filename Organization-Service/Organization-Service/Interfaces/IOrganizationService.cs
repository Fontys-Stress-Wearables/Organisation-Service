using Organization_Service.Models;

namespace Organization_Service.Interfaces;

public interface IOrganizationService
{
    public IEnumerable<Organization> GetAll();

    public Organization GetOrganization(string id);

    public Organization CreateOrganization(string name);

    public Organization EditOrganizationName(string id, string name);
}