using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Organization_Service.Dtos;
using Organization_Service.Interfaces;

namespace Organization_Service.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("organizations/{organizationId}")]
public class OrganizationAdminController
{
    private readonly IOrganizationAdminService _organizationAdminService;
    private readonly IMapper _mapper;

    public OrganizationAdminController
    (
        IOrganizationAdminService organizationAdminService,
        IMapper mapper
    )
    {
        _organizationAdminService = organizationAdminService;
        _mapper = mapper;
    }
    
    [HttpGet("admins")]
    public IEnumerable<OrganizationAdminDto> GetOrganizationAdmins()
    {
        var organizations = _organizationAdminService.GetAll();

        return _mapper.Map<IEnumerable<OrganizationAdminDto>>(organizations);
    }
    
    [HttpPost("admins")]
    public OrganizationAdminDto CreateOrganizationAdmin(CreateOrganizationAdminDto organizationAdmin)
    {
        var organizationAdminData = _organizationAdminService.CreateOrganizationAdmin(
            organizationAdmin.Name, organizationAdmin.EmailAddress, organizationAdmin.IsArchived);

        return _mapper.Map<OrganizationAdminDto>(organizationAdminData);
    }
    
    [HttpGet("admins/{id}")]
    public OrganizationAdminDto GetOrganizationAdmin(string id)
    {
        var organizationAdmin = _organizationAdminService.GetOrganizationAdmin(id);

        return _mapper.Map<OrganizationAdminDto>(organizationAdmin);
    }
    
    [HttpPut("admins/{id}")]
    public OrganizationAdminDto UpdateOrganizationAdmin(string id, UpdateOrganizationAdminDto organizationAdmin)
    {
        var organizationAdminData = _organizationAdminService.UpdateOrganizationAdmin(
            id, organizationAdmin.Name, organizationAdmin.EmailAddress, organizationAdmin.IsArchived);

        return _mapper.Map<OrganizationAdminDto>(organizationAdminData);
    }
    
    [HttpDelete("admins/{id}")]
    public OrganizationAdminDto RemoveOrganizationAdmin(string id)
    {
        var organizationAdminData = _organizationAdminService.RemoveOrganizationAdmin(id);

        return _mapper.Map<OrganizationAdminDto>(organizationAdminData);
    }
}