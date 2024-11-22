using EmailServices.Domain.Repositories;
using EmailServices.Domain.Repositories.Tenants;
using EmailServices.Domain.Security.Cryptography;
using EmailServices.Domain.Services.Key;
using EmailServices.Infrastructure.DataAccess;
using EmailServices.Infrastructure.DataAccess.Repositories;
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
        services.AddScoped<Key, GenetarorKeys>();

        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ITenantsRepository, TenantsRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        services.AddDbContext<EmailServicesDbContext>(config => config.UseNpgsql(connectionString));
    }
}
