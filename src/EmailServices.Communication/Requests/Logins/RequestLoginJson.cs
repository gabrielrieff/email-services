namespace EmailServices.Communication.Requests.Logins;

public class RequestLoginJson
{
    public string Domain { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}