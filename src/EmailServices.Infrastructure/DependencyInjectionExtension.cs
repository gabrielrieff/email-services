using EmailServices.Domain.Repositories;
using EmailServices.Domain.Repositories.Smtps;
using EmailServices.Domain.Repositories.Tenants;
using EmailServices.Domain.Security.Cryptography;
using EmailServices.Domain.Services.Keys;
using EmailServices.Infrastructure.DataAccess;
using EmailServices.Infrastructure.DataAccess.Repositories;
using EmailServices.Infrastructure.DataAccess.Repositories.Smtps;
using EmailServices.Infrastructure.DataAccess.Repositories.Tenants;
using EmailServices.Infrastructure.Services.Keys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailServices.Infrastructure;

public static class DependencyInjectionExtension
{
    static public void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
        services.AddScoped<IKey, GenetarorKeys>();

        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ITenantsWhiteOnlyRepository, TenantsWhiteOnlyRepository>();
        services.AddScoped<ISmtpRepository, SmtpRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        services.AddDbContext<EmailServicesDbContext>(config => config.UseNpgsql(connectionString));
    }
}
