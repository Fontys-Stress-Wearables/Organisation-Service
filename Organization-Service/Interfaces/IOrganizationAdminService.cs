using Organization_Service.Models;

namespace Organization_Service.Interfaces;

public interface IOrganizationAdminService
{
    public OrganizationAdmin CreateOrganizationAdmin(string name, string emailaddress, Boolean isarchived);
}