using AutoMapper;
using Organization_Service.Dtos;
using Organization_Service.Models;

namespace Organization_Service.Profiles;

public class OrganizationAdminProfile : Profile
{
    public OrganizationAdminProfile()
    {
        CreateMap<OrganizationAdmin, OrganizationAdminDto>();
    }
}