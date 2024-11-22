using EmailServices.Communication.Requests;
using EmailServices.Communication.Response;

namespace EmailServices.Application.UseCase.Tenants.Register;
public interface IRegisterTenantUseCase
{
    Task<ResponseRegisterTenant> Execute(RequestRegisterTenant request);
}
