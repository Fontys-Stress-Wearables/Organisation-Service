using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Organization_Service.Dtos;
using Organization_Service.Interfaces;

namespace Organization_Service.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("[controller]")]
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
    
    [HttpPost("admins")]
    public OrganizationAdminDto CreateOrganizationAdmin(CreateOrganizationAdminDto organizationAdmin)
    {
        var organizationAdminData = _organizationAdminService.CreateOrganizationAdmin(
            organizationAdmin.Name, organizationAdmin.EmailAddress, organizationAdmin.IsArchived);

        return _mapper.Map<OrganizationAdminDto>(organizationAdminData);
    }
}