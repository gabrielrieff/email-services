using EmailServices.Domain.Entities;

namespace EmailServices.Domain.Security.Tokens;

public interface IAccessTokenGenerator
{
    string Generate(Tenant tenant);
}