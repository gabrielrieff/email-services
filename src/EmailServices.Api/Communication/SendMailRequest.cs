namespace EmailServices.Api.Communication;

public class SendMailRequest
{
    public List<string> To { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
}