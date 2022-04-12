namespace Organization_Service.Models;

public class Organization
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public virtual IEnumerable<OrganizationAdmin> OrganizationAdmins { get; set; } = new List<OrganizationAdmin>();
}