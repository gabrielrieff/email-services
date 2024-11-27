using AutoMapper;
using EmailServices.Communication.Requests.Tenants;
using EmailServices.Communication.Response;
using EmailServices.Domain.Entities;
using EmailServices.Domain.Repositories;
using EmailServices.Domain.Repositories.Tenants;
using EmailServices.Domain.Security.Cryptography;
using EmailServices.Domain.Services.Key;
using EmailServices.Exception.ExceptionBase;

namespace EmailServices.Application.UseCase.Tenants.Register;

public class RegisterTenantUseCase : IRegisterTenantUseCase
{
    private readonly ITenantsRepository _repo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _encrypter;
    private readonly Key _generateKey;


    public RegisterTenantUseCase(
        ITenantsRepository repo,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IPasswordEncripter encrypter,
        Key generateKey)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _encrypter = encrypter;
        _generateKey = generateKey;
    }

    public async Task<ResponseRegisterTenant> Execute(RequestRegisterTenant request)
    {
        Validate(request);

        var tenant = _mapper.Map<Tenant>(request);
        tenant.Password = _encrypter.Encrypt(request.Password);
        tenant.ApiKey = _generateKey.GeneratorApiKey();
        tenant.TenantIdentifier = Guid.NewGuid();

        await _repo.Add(tenant);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisterTenant>(tenant);
    }

    private void Validate(RequestRegisterTenant request)
    {
        var result = new RegisterTenantValidator().Validate(request);

        if (result.IsValid == false)
        {
            var errorMessagens = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessagens);
        }
    }
}
