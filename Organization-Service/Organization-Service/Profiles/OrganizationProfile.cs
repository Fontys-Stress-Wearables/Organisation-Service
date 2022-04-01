using AutoMapper;
using Organization_Service.Dtos;
using Organization_Service.Models;

namespace Organization_Service.Profiles;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<Organization, OrganizationDto>();
    }
}