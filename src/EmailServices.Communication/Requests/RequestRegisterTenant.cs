namespace EmailServices.Communication.Requests;

public class RequestRegisterTenant
{
    public string Name { get; set; } = string.Empty;

    public string Domain { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
