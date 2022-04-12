using Organization_Service.Models;

namespace Organization_Service.Interfaces;

public interface IOrganizationAdminService
{
    public IEnumerable<OrganizationAdmin> GetAll(string organizationId);
    public OrganizationAdmin GetOrganizationAdmin(string organizationId, string adminId);
    public OrganizationAdmin CreateOrganizationAdmin(string organizationId, string name, Boolean isarchived);
    public OrganizationAdmin UpdateOrganizationAdmin(string organizationId, string adminId, string name, Boolean isarchived);
    public OrganizationAdmin RemoveOrganizationAdmin(string organizationId, string adminId);
}