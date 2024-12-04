using System.Net.Mail;
using System.Text.RegularExpressions;
using EmailServices.Api.Interfaces;

namespace EmailServices.Api.Services;

public class SendMailServices : ISendMailServices
{
    private readonly SmtpClient _smtpClient;
    
    public SendMailServices(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }

    public async Task SendMail(List<string> emailsTo, string subject, string body, bool isHtml)
    {
        var mail = PrepareMessage(emailsTo, subject, body, isHtml);

        await _smtpClient.SendMailAsync(mail);
    }

    private MailMessage PrepareMessage(List<string> emailsTo, string subject, string body, bool isHtml)
    {
        var mail = new MailMessage
        {
            From = new MailAddress("gabeerieff@gmail.com", "Equipe finance flow"), // Altere para um endereço válido
            Subject = subject,
            Body = body,
            IsBodyHtml = isHtml
        };

        foreach (var email in emailsTo)
        {
            if (ValidateEmail(email))
            {
                mail.To.Add(email);
            }
        }

        return mail;
    }

    private bool ValidateEmail(string email)
    {
        Regex expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
        return expression.IsMatch(email);
    }
}