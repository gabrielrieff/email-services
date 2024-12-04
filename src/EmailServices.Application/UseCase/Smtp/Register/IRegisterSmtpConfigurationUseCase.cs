using EmailServices.Communication.Requests.SmtpConfiguration;

namespace EmailServices.Application.UseCase.Smtp.Register;
public interface IRegisterSmtpConfigurationUseCase
{
    Task Execute(RequestRegisterSmtpConfiguration request);
}
