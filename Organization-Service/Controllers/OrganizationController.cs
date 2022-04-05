using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Organization_Service.Dtos;
using Organization_Service.Interfaces;
using Organization_Service.Models;

namespace Organization_Service.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("[controller]")]
public class OrganizationController : Controller
{
    private readonly IOrganizationService _organizationService;
    private readonly INatsService _natsService;
    private readonly IMapper _mapper;

    public OrganizationController
    (
        IOrganizationService organizationService, INatsService natsService,
        IMapper mapper
    )
    {
        _organizationService = organizationService;
        _natsService = natsService;
        _mapper = mapper;
    }

    [HttpGet("organizations/getall")]
    public IEnumerable<OrganizationDto> GetOrganizations()
    {
        var organizations = _organizationService.GetAll();

        return _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
    }
    
    [HttpGet("organizations/get/{id}")]
    public OrganizationDto GetOrganization(string id)
    {
        var organization = _organizationService.GetOrganization(id);

        return _mapper.Map<OrganizationDto>(organization);
    }

    [HttpPost("organizations/create")]
    public OrganizationDto CreateOrganization(CreateOrganizationDto organization)
    {
        var organizationData = _organizationService.CreateOrganization(organization.Name);
        // _natsService.Publish("", organizationData);

        return _mapper.Map<OrganizationDto>(organizationData);
    }

    [HttpPut("organizations/updatename")]
    public OrganizationDto UpdateOrganizationName(OrganizationDto organization)
    {
        var organizationData = _organizationService.UpdateOrganizationName(organization.Id, organization.Name);

        return _mapper.Map<OrganizationDto>(organizationData);
    }
    
    [HttpDelete("organizations/remove/{id}")]
    public OrganizationDto RemoveOrganization(string id)
    {
        var organizationData = _organizationService.RemoveOrganization(id);

        return _mapper.Map<OrganizationDto>(organizationData);
    }
}