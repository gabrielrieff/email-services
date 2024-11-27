using EmailServices.Communication.Requests.Logins;
using EmailServices.Domain.Repositories.Tenants;
using EmailServices.Domain.Security.Cryptography;
using EmailServices.Domain.Security.Tokens;
using EmailServices.Exception.ExceptionBase;

namespace EmailServices.Application.UseCase.Login;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly ITenantsReadOnlyRepository _repository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    
    public DoLoginUseCase(
        ITenantsReadOnlyRepository repository,
        IPasswordEncripter passwordEncripter,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _repository = repository;
        _passwordEncripter = passwordEncripter;
        _accessTokenGenerator = accessTokenGenerator;
    }


    public async Task<ResponseRegisteredTenantJson> Execute(RequestLoginJson request)
    {
        var tenant = await _repository.GetTenantByDomain(request.Domain);

        if (tenant is null)
        {
            throw new InvalidLoginExpection();
        }
        
        var passwordMatch = _passwordEncripter.Verify(request.Password, tenant.Password);

        return new ResponseRegisteredTenantJson
        {
            Name = tenant.Name,
            Token = _accessTokenGenerator.Generate(tenant)
        };
    }
}