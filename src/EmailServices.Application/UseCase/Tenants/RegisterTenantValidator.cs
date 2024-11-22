using EmailServices.Communication.Requests;
using FluentValidation;

namespace EmailServices.Application.UseCase.Tenants;

public class RegisterTenantValidator : AbstractValidator<RequestRegisterTenant>
{
    public RegisterTenantValidator()
    {
        RuleFor(tenant => tenant.Name).NotEmpty()
            .WithMessage("Name required.");
        RuleFor(tenant => tenant.Password).NotEmpty()
            .WithMessage("Password required.");
        RuleFor(tenant => tenant.Domain).NotEmpty()
            .WithMessage("Domain required.");

    }
}
