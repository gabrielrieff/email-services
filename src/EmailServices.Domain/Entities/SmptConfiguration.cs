namespace EmailServices.Domain.Entities;

public class SmptConfiguration
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SmtpServer { get; set; } = string.Empty;
    public int SmtpPort { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string DefaultFrom { get; set; } = string.Empty;
    public long TenantId { get; set; } = default!;
    public Tenant Tenant { get; set; } = default!;
}
