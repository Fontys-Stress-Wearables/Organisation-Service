using Organization_Service.Interfaces;
using Organization_Service.Models;

namespace Organization_Service.Data;

public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
{
    public OrganizationRepository(DatabaseContext context) : base(context)
    {
        
    }
}