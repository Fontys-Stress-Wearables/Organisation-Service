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
}