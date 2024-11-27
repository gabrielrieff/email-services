using EmailServices.Domain.Entities;
using EmailServices.Domain.Repositories.Tenants;
using Microsoft.EntityFrameworkCore;

namespace EmailServices.Infrastructure.DataAccess.Repositories.Tenants;

internal class TenantsWhiteOnlyRepository : ITenantsWhiteOnlyRepository, ITenantsReadOnlyRepository
{
    private readonly EmailServicesDbContext _dbContext;

    public TenantsWhiteOnlyRepository(EmailServicesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Tenant tenant)
    {
        await _dbContext.Tenants.AddAsync(tenant);
    }

    public async Task<Tenant?> GetTenantByDomain(string domain)
    {
        return await _dbContext.Tenants.AsNoTracking().FirstOrDefaultAsync(tenant => tenant.Domain == domain); 
    }
}
