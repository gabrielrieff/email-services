using EmailServices.Domain.Entities;

namespace EmailServices.Domain.Repositories.Tenants;
public interface ITenantsRepository
{
    Task Add(Tenant tenant);
}
