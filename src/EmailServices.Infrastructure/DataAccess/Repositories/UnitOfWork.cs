using EmailServices.Domain.Repositories;

namespace EmailServices.Infrastructure.DataAccess.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly EmailServicesDbContext _dbContext;

    public UnitOfWork(EmailServicesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
