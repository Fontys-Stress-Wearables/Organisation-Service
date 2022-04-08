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

    public IEnumerable<OrganizationAdmin> GetAll()
    {
        return _unitOfWork.Admins.GetAll();
    }

    public OrganizationAdmin GetOrganizationAdmin(string id)
    {
        var organizationAdmin = _unitOfWork.Admins.GetById(id);

        if (organizationAdmin == null)
        {
            throw new NotFoundException($"Admin with id '{id}' doesn't exist.");
        }

        return organizationAdmin;
    }

    public OrganizationAdmin CreateOrganizationAdmin(string name, string emailaddress, Boolean isarchived)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BadRequestException("Name cannot be empty.");
        }

        var organizationAdmin = new OrganizationAdmin()
        {
            Name = name,
            EmailAddress = emailaddress,
            IsArchived = isarchived,
            Id = Guid.NewGuid().ToString()
        };
        
        _unitOfWork.Admins.Add(organizationAdmin);
        _unitOfWork.Complete();

        return organizationAdmin;
    }

    public OrganizationAdmin UpdateOrganizationAdmin(
        string id, string name, string emailaddress, Boolean isarchived
    )
    {
        var organizationAdmin = _unitOfWork.Admins.GetById(id);

        if (organizationAdmin == null)
        {
            throw new NotFoundException($"Admin with id '{id}' doesn't exist.");
        }

        organizationAdmin.Name = name;
        organizationAdmin.EmailAddress = emailaddress;
        organizationAdmin.IsArchived = isarchived;
        _unitOfWork.Admins.Update(organizationAdmin);
        _unitOfWork.Complete();

        return organizationAdmin;
    }

    public OrganizationAdmin RemoveOrganizationAdmin(string id)
    {
        var organizationAdmin = _unitOfWork.Admins.GetById(id);
        
        if (organizationAdmin == null)
        {
            throw new NotFoundException($"Admin with id '{id}' doesn't exist.");
        }
        
        _unitOfWork.Admins.Remove(organizationAdmin);
        _unitOfWork.Complete();

        return organizationAdmin;
    }
}