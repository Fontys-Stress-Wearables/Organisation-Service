using Organization_Service.Models;

namespace Organization_Service.Interfaces;

public interface IOrganizationAdminService
{
    public IEnumerable<OrganizationAdmin> GetAll();
    public OrganizationAdmin GetOrganizationAdmin(string id);
    public OrganizationAdmin CreateOrganizationAdmin(string name, string emailaddress, Boolean isarchived);
    public OrganizationAdmin UpdateOrganizationAdmin(string id, string name, string emailaddress, Boolean isarchived);
    public OrganizationAdmin RemoveOrganizationAdmin(string id);
}