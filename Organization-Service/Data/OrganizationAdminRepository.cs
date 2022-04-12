using Organization_Service.Interfaces;
using Organization_Service.Models;
using technology_poc.Data;

namespace Organization_Service.Data;

public class OrganizationAdminRepository : GenericRepository<OrganizationAdmin>, IOrganizationAdminRepository
{
    public OrganizationAdminRepository(DatabaseContext context) : base(context)
    {
        
    }
}