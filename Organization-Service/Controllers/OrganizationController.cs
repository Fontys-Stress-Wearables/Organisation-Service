using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Organization_Service.Dtos;
using Organization_Service.Interfaces;

namespace Organization_Service.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("organizations")]

public class OrganizationController : Controller
{
    private readonly IOrganizationService _organizationService;
    // private readonly INatsService _natsService;
    private readonly IMapper _mapper;

    public OrganizationController
    (
        IOrganizationService organizationService,
        // INatsService natsService,
        IMapper mapper
    )
    {
        _organizationService = organizationService;
        // _natsService = natsService;
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
        // _natsService.Publish("", organizationData);

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
        var organizationData = _organizationService.UpdateOrganization(id, organization.Name);

        return _mapper.Map<OrganizationDto>(organizationData);
    }
    
    [HttpDelete("{id}")]
    public OrganizationDto RemoveOrganization(string id)
    {
        var organizationData = _organizationService.RemoveOrganization(id);

        return _mapper.Map<OrganizationDto>(organizationData);
    }
}