using EmailServices.Communication.Requests.SmtpConfiguration;
using FluentValidation;

namespace EmailServices.Application.UseCase.Smtp;

public class RegisterStmpValidator : AbstractValidator<RequestRegisterSmtpConfiguration>
{
    public RegisterStmpValidator()
    {
        RuleFor(smtp => smtp.SmtpPort).NotEmpty()
            .WithMessage("Inform port smtp required.");
        RuleFor(smtp => smtp.PasswordSmtp).NotEmpty()
            .WithMessage("Inform Password smtp required.");
        RuleFor(smtp => smtp.SmtpServer).NotEmpty()
            .WithMessage("Inform your required.");
        RuleFor(smtp => smtp.Username).NotEmpty()
            .WithMessage("Inform Domain required.");

    }
}
