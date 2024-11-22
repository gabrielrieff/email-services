using EmailServices.Domain.Enums;

namespace EmailServices.Domain.Entities;

public class EmailRequest : BaseEntity
{
    public List<string> To { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public StatusEmail EmailStatus { get; set; }
    public long SmtpConfigurationId { get; set; }
    public SmptConfiguration SmtpConfiguration { get; set; } = default!;
}
