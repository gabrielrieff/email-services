using EmailServices.Domain.Entities;

namespace EmailServices.Domain.Repositories.Tenants;
public interface ITenantsWhiteOnlyRepository
{
    Task Add(Tenant tenant);
}
