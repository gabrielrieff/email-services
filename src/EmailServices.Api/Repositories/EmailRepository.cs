//using EmailServices.Api.DataAccess;
using EmailServices.Api.Entities;
using EmailServices.Api.Interfaces;
using MongoDB.Driver;

namespace EmailServices.Api.Repositories;

public class EmailRepository : IEmailRepository
{
    private readonly IMongoCollection<Email> _emailsCollection;

    public EmailRepository(IMongoDatabase database)
    {
        _emailsCollection = database.GetCollection<Email>("Emails");
    }

    public async Task Add(Email email)
    {
        //await _emailsCollection.Emails.AddAsync(email);
    }
}