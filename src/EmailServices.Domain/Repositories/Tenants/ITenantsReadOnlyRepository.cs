using EmailServices.Domain.Entities;

namespace EmailServices.Domain.Repositories.Tenants;
public interface ITenantsReadOnlyRepository
{
    Task<Tenant?> GetTenantByDomain(string domain);
}
