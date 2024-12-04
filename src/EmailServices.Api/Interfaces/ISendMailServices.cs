namespace EmailServices.Api.Interfaces;

public interface ISendMailServices
{
    Task SendMail(List<string> emailsTo, string subject, string body, bool isHtml = true);
}