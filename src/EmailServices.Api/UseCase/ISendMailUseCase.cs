using EmailServices.Api.Communication;

namespace EmailServices.Api.UseCase;

public interface ISendMailUseCase
{
    Task<SendMailResponse> Execute(SendMailRequest request);
}