namespace Organization_Service.Dtos;

public class OrganizationAdminDto
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string EmailAddress { get; set; } = "";
    public Boolean IsArchived { get; set; } = false;
}