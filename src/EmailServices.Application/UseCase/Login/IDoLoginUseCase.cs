using EmailServices.Communication.Requests.Logins;

namespace EmailServices.Application.UseCase.Login;

public interface IDoLoginUseCase
{
    Task<ResponseRegisteredTenantJson> Execute(RequestLoginJson request);
}