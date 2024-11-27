using EmailServices.Domain.Entities;

namespace EmailServices.Domain.Services.LoggedUser;

public interface ILoggedUser
{
    Task<Tenant> Get();
}