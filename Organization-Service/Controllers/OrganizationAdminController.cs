using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Organization_Service.Dtos;
using Organization_Service.Interfaces;

namespace Organization_Service.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("organizations/{organizationId}/admins")]
public class OrganizationAdminController
{
    private readonly IOrganizationAdminService _organizationAdminService;
    private readonly INatsService _natsService;
    private readonly IMapper _mapper;

    public OrganizationAdminController
    (
        IOrganizationAdminService organizationAdminService,
        INatsService natsService,
        IMapper mapper
    )
    {
        _organizationAdminService = organizationAdminService;
        _natsService = natsService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IEnumerable<OrganizationAdminDto> GetOrganizationAdmins(string organizationId)
    {
        var organizations = _organizationAdminService.GetAll(organizationId);

        return _mapper.Map<IEnumerable<OrganizationAdminDto>>(organizations);
    }
    
    [HttpPost]
    public OrganizationAdminDto CreateOrganizationAdmin(string organizationId, CreateOrganizationAdminDto organizationAdmin)
    {
        var organizationAdminData = _organizationAdminService.CreateOrganizationAdmin(organizationId, organizationAdmin.Name);
        _natsService.Publish("organization-admin-created", organizationAdminData);

        return _mapper.Map<OrganizationAdminDto>(organizationAdminData);
    }
    
    [HttpGet("{id}")]
    public OrganizationAdminDto GetOrganizationAdmin(string organizationId, string id)
    {
        var organizationAdmin = _organizationAdminService.GetOrganizationAdmin(organizationId, id);

        return _mapper.Map<OrganizationAdminDto>(organizationAdmin);
    }
    
    [HttpPut("{id}")]
    public OrganizationAdminDto UpdateOrganizationAdmin(string organizationId, string id, UpdateOrganizationAdminDto organizationAdmin)
    {
        var organizationAdminData = _organizationAdminService.UpdateOrganizationAdmin(
            organizationId, id, organizationAdmin.Name, organizationAdmin.IsArchived);

        return _mapper.Map<OrganizationAdminDto>(organizationAdminData);
    }
    
    [HttpDelete("{id}")]
    public void RemoveOrganizationAdmin(string organizationId, string id)
    {
        _organizationAdminService.RemoveOrganizationAdmin(organizationId, id);
    }
}