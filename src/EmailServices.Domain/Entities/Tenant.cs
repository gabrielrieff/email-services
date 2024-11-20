namespace EmailServices.Domain.Entities;

public class Tenant
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public string ApiKey { get; set; } = string.Empty;

    public Guid TenantIdentifier { get; set; }
}
