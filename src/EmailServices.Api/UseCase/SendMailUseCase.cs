using EmailServices.Api.Communication;
using EmailServices.Api.Interfaces;
using EmailServices.Api.Repositories;

namespace EmailServices.Api.UseCase;

public class SendMailUseCase : ISendMailUseCase
{
    //private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailRepository _emailRepo;
    private readonly ISendMailServices _sendMailServices;
    
    public SendMailUseCase(IEmailRepository emailRepo, ISendMailServices sendMailServices)
    {
        //_unitOfWork = unitOfWork;
        _emailRepo = emailRepo;
        _sendMailServices = sendMailServices;
    }

    public async Task<SendMailResponse> Execute(SendMailRequest request)
    {
        await _sendMailServices.SendMail(
            emailsTo: ["gabrielrieff1@gmail.com"],
            subject: "teste",
            body: "Novo email"
        );

        return new SendMailResponse
        {
            Ok = "E-mail enviado com sucesso"
        };
    }
}