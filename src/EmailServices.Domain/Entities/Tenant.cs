namespace EmailServices.Domain.Entities;

public class Tenant : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Domain { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ApiKey { get; set; } = string.Empty;

    public string CodeToRecoverPassword { get; set; } = string.Empty;

    public Guid TenantIdentifier { get; set; }
}
