using AutoMapper;
using EmailServices.Communication.Requests.SmtpConfiguration;
using EmailServices.Domain.Entities;
using EmailServices.Domain.Repositories;
using EmailServices.Domain.Repositories.Smtps;
using EmailServices.Domain.Services.LoggedUser;
using EmailServices.Exception.ExceptionBase;

namespace EmailServices.Application.UseCase.Smtp.Register;

public class RegisterSmtpConfigurationUseCase : IRegisterSmtpConfigurationUseCase
{
    private readonly ISmtpRepository _smtp;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _logged;
    
    public RegisterSmtpConfigurationUseCase(ISmtpRepository smtp, IMapper mapper, IUnitOfWork unitOfWork, ILoggedUser logged)
    {
        _smtp = smtp;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _logged = logged;
    }

    public async Task Execute(RequestRegisterSmtpConfiguration request)
    {
        Validate(request);
        var loggedUser = await _logged.Get();
        
        var smtpConfig = _mapper.Map<SmtpConfiguration>(request);
        
        smtpConfig.TenantId = loggedUser.Id;
        
        await _smtp.Add(smtpConfig);
        await _unitOfWork.Commit();
    }
    
    private void Validate(RequestRegisterSmtpConfiguration request)
    {
        var result = new RegisterStmpValidator().Validate(request);

        if (result.IsValid == false)
        {
            var errorMessagens = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessagens);
        }
    }
}
