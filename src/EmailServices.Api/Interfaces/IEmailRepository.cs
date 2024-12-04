using EmailServices.Api.Entities;

namespace EmailServices.Api.Interfaces;

public interface IEmailRepository
{
    Task Add(Email email);
}