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
    public IEnumerable<OrganizationAdminDto> GetOrganizationAdmins(string organizationId)
    {
        var organizations = _organizationAdminService.GetAll(organizationId);

        return _mapper.Map<IEnumerable<OrganizationAdminDto>>(organizations);
    }
    
    [HttpPost("admins")]
    public OrganizationAdminDto CreateOrganizationAdmin(string organizationId, CreateOrganizationAdminDto organizationAdmin)
    {
        var organizationAdminData = _organizationAdminService.CreateOrganizationAdmin(organizationId, 
            organizationAdmin.Name, organizationAdmin.IsArchived);

        return _mapper.Map<OrganizationAdminDto>(organizationAdminData);
    }
    
    [HttpGet("admins/{id}")]
    public OrganizationAdminDto GetOrganizationAdmin(string organizationId, string id)
    {
        var organizationAdmin = _organizationAdminService.GetOrganizationAdmin(organizationId, id);

        return _mapper.Map<OrganizationAdminDto>(organizationAdmin);
    }
    
    [HttpPut("admins/{id}")]
    public OrganizationAdminDto UpdateOrganizationAdmin(string organizationId, string id, UpdateOrganizationAdminDto organizationAdmin)
    {
        var organizationAdminData = _organizationAdminService.UpdateOrganizationAdmin(
            organizationId, id, organizationAdmin.Name, organizationAdmin.IsArchived);

        return _mapper.Map<OrganizationAdminDto>(organizationAdminData);
    }
    
    [HttpDelete("admins/{id}")]
    public OrganizationAdminDto RemoveOrganizationAdmin(string organizationId, string id)
    {
        var organizationAdminData = _organizationAdminService.RemoveOrganizationAdmin(organizationId, id);

        return _mapper.Map<OrganizationAdminDto>(organizationAdminData);
    }
}