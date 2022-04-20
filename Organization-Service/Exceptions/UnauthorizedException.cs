using System.Net;

namespace Organization_Service.Exceptions;

public class UnauthorizedException : AppException
{
    public UnauthorizedException(string message) : base(HttpStatusCode.Unauthorized, message) { }
}