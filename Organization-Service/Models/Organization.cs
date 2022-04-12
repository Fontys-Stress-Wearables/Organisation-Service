namespace Organization_Service.Models;

public class Organization
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public virtual ICollection<OrganizationAdmin> OrganizationAdmins { get; set; } = new List<OrganizationAdmin>();
}