namespace EmailServices.Domain.Entities;

public class EmailRequest
{
    public string To { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public long SmtpConfigurationId { get; set; }
    public SmptConfiguration SmtpConfiguration { get; set; } = default!;
}
