using Microsoft.Identity.Web;
using Organization_Service.Exceptions;
using Organization_Service.Interfaces;

namespace Organization_Service.Middlewares;

public class OrganizationAuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public OrganizationAuthorizationMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _configuration = config;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var tenant = context.User.GetTenantId();

        if (tenant == null)
        {
            throw new NotFoundException("tenant not found");
        }

        if (tenant!=_configuration["tenant"])
        {
            throw new NotFoundException("tenant not found");
        }

        await _next(context);
    }
}

public static class OrganizationAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseOrganizationAuthorization(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<OrganizationAuthorizationMiddleware>();
    }
}