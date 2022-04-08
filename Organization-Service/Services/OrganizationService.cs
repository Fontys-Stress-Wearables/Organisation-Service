using Organization_Service.Interfaces;
using Organization_Service.Exceptions;
using Organization_Service.Models;

namespace Organization_Service.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrganizationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Organization> GetAll()
    {
        return _unitOfWork.Organizations.GetAll();
    }

    public Organization GetOrganization(string id)
    {
        var organization = _unitOfWork.Organizations.GetById(id);

        if (organization == null)
        {
            throw new NotFoundException($"Organization with id '{id}' doesn't exist.");
        }

        return organization;
    }

    public Organization CreateOrganization(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BadRequestException("Name cannot be empty.");
        }

        var organization = new Organization()
        {
            Name = name,
            Id = Guid.NewGuid().ToString()
        };

        _unitOfWork.Organizations.Add(organization);
        _unitOfWork.Complete();

        return organization;
    }

    public Organization UpdateOrganization(string id, string name)
    {
        var organization = _unitOfWork.Organizations.GetById(id);

        if (organization == null)
        {
            throw new NotFoundException($"Organization with id '{id}' doesn't exist.");
        }
        
        organization.Name = name;
        _unitOfWork.Organizations.Update(organization);
        _unitOfWork.Complete();
        
        return organization;
    }
    
    public Organization RemoveOrganization(string id)
    {
        var organization = _unitOfWork.Organizations.GetById(id);

        if (organization == null)
        {
            throw new NotFoundException($"Organization with id '{id}' doesn't exist.");
        }
        
        _unitOfWork.Organizations.Remove(organization);
        _unitOfWork.Complete();
        
        return organization;
    }
}