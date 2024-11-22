namespace EmailServices.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
