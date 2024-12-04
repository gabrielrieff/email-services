using EmailServices.Api.DataAccess;
using EmailServices.Api.Interfaces;

namespace EmailServices.Api.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly EmailServicesDContext _dbContext;
    public UnitOfWork(EmailServicesDContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}