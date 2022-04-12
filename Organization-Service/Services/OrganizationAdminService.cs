using Organization_Service.Exceptions;
using Organization_Service.Interfaces;
using Organization_Service.Models;

namespace Organization_Service.Services;

public class OrganizationAdminService : IOrganizationAdminService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrganizationAdminService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<OrganizationAdmin> GetAll(string organizationId)
    {
        var organization = GetOrganization(organizationId);
        
        return organization.OrganizationAdmins;
    }

    public OrganizationAdmin GetOrganizationAdmin(string organizationId, string adminId)
    {
        var organization = GetOrganization(organizationId);

        return GetAdminFromOrganization(organization, adminId);
    }

    public OrganizationAdmin CreateOrganizationAdmin(string organizationId, string name, Boolean isarchived)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BadRequestException("Name cannot be empty.");
        }

        var organizationAdmin = new OrganizationAdmin()
        {
            Name = name,
            IsArchived = isarchived,
            Id = Guid.NewGuid().ToString()
        };
        
        
        var organization = GetOrganization(organizationId);
        
        organization.OrganizationAdmins.Add(organizationAdmin);
        _unitOfWork.Organizations.Update(organization);
        _unitOfWork.Complete();

        return organizationAdmin;
    }

    public OrganizationAdmin UpdateOrganizationAdmin(string organizationId, string adminId, string name, Boolean isarchived)
    {
        var organization = GetOrganization(organizationId);

        var organizationAdmin = GetAdminFromOrganization(organization, adminId);

        organization.OrganizationAdmins.Remove(organizationAdmin);
        
        organizationAdmin.Name = name;
        organizationAdmin.IsArchived = isarchived;

        // var organizationAdmins = organization.OrganizationAdmins;
        // organizationAdmins.a

        organization.OrganizationAdmins.Add(organizationAdmin);
        _unitOfWork.Organizations.Update(organization);
        _unitOfWork.Complete();

        return organizationAdmin;
    }

    public OrganizationAdmin RemoveOrganizationAdmin(string organizationId, string adminId)
    {
        var organization = GetOrganization(organizationId);

        var organizationAdmin = GetAdminFromOrganization(organization, adminId);
        
        organization.OrganizationAdmins.Remove(organizationAdmin);
        _unitOfWork.Organizations.Update(organization);
        _unitOfWork.Complete();

        return organizationAdmin;
    }

    private Organization GetOrganization(string id)
    {
        var organization = _unitOfWork.Organizations.GetById(id);

        if (organization == null)
        {
            throw new NotFoundException($"Organization with id '{id}' doesn't exist.");
        }

        return organization;
    }

    private OrganizationAdmin GetAdminFromOrganization(Organization organization, string id)
    {
        var organizationAdmin = organization.OrganizationAdmins.ToList().FirstOrDefault(admin=> admin.Id == id);  
        
        if (organizationAdmin == null)
        {
            throw new NotFoundException($"Admin with id '{id}' doesn't exist.");
        }

        return organizationAdmin;
    }
}