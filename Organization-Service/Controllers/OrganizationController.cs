using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organization_Service.Dtos;
using Organization_Service.Interfaces;

namespace Organization_Service.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("organizations")]
[Authorize]

public class OrganizationController : Controller
{
    private readonly IOrganizationService _organizationService;
    private readonly IMapper _mapper;

    public OrganizationController
    (
        IOrganizationService organizationService,
        IMapper mapper
    )
    {
        _organizationService = organizationService;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<OrganizationDto> GetOrganizations()
    {
        var organizations = _organizationService.GetAll();

        return _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
    }
    
    [HttpPost]
    public OrganizationDto CreateOrganization(CreateOrganizationDto organization)
    {
        var organizationData = _organizationService.CreateOrganization(organization.Name);

        return _mapper.Map<OrganizationDto>(organizationData);
    }
    
    [HttpGet("{id}")]
    public OrganizationDto GetOrganization(string id)
    {
        var organization = _organizationService.GetOrganization(id);

        return _mapper.Map<OrganizationDto>(organization);
    }

    [HttpPut("{id}")]
    public OrganizationDto UpdateOrganization(string id, UpdateOrganizationDto organization)
    {
        var organizationData = _organizationService.UpdateOrganizationName(id, organization.Name);

        return _mapper.Map<OrganizationDto>(organizationData);
    }
    
    [HttpDelete("{id}")]
    public void RemoveOrganization(string id)
    {
        _organizationService.RemoveOrganization(id);
    }
}