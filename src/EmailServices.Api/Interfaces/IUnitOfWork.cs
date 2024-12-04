namespace EmailServices.Api.Interfaces;

public interface IUnitOfWork
{
    Task Commit();
}