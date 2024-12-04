using System.Net;
using System.Net.Mail;
using EmailServices.Api.Interfaces;
using EmailServices.Api.Repositories;
using EmailServices.Api.Services;
using EmailServices.Api.UseCase;
//using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace EmailServices.Api;

public static class DependecyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services) 
    {
        AddUseCases(services);
    }

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
    {
        ConfigureServices(services, configuration);
        AddRepositories(services);
        AddDbContext(services, configuration);
    }
    
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ISendMailUseCase, SendMailUseCase>();
    }
    
    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
    
        var Host = configuration.GetValue<string>("Settings:Smtp:Host");
        var Port = configuration.GetValue<int>("Settings:Smtp:Port");
        var Username = configuration.GetValue<string>("Settings:Smtp:Username");
        var Password = configuration.GetValue<string>("Settings:Smtp:Password");
        var EnableSsl = configuration.GetValue<bool>("Settings:Smtp:EnableSsl");
    
    
        services.AddScoped(provider =>
        {
            var smtpClient = new SmtpClient(Host)
            {
                Port = Port,
                Credentials = new NetworkCredential(Username, Password),
                EnableSsl = EnableSsl,
                Timeout = 50000,
                UseDefaultCredentials = false,
            };
            return smtpClient;
        });
        services.AddScoped<ISendMailServices, SendMailServices>();
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmailRepository, EmailRepository>();
    }
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDbConnection");
        var databaseName = configuration.GetSection("MongoDbSettings:DatabaseName").Value;

        services.AddSingleton<IMongoClient>(sp => new MongoClient(connectionString));
        services.AddScoped(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(databaseName);
        });
        
    }
    
}