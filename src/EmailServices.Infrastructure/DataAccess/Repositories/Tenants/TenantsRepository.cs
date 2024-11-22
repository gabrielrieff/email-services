using EmailServices.Domain.Entities;
using EmailServices.Domain.Repositories.Tenants;

namespace EmailServices.Infrastructure.DataAccess.Repositories.Tenants;

internal class TenantsRepository : ITenantsRepository
{
    private readonly EmailServicesDbContext _dbContext;

    public TenantsRepository(EmailServicesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Tenant tenant)
    {
        await _dbContext.Tenants.AddAsync(tenant);
    }
}
