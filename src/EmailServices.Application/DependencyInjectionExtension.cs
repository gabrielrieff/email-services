
using EmailServices.Application.AutoMapper;
using EmailServices.Application.UseCase.Tenants.Register;
using Microsoft.Extensions.DependencyInjection;

namespace EmailServices.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddAutoMapper(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterTenantUseCase, RegisterTenantUseCase>();

    }
}
