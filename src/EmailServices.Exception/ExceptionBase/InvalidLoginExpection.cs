using System.Net;

namespace EmailServices.Exception.ExceptionBase;

public class InvalidLoginExpection : EmailServicesException
{
    public InvalidLoginExpection() : base("")
    {

    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}