namespace EmailServices.Exception.ExceptionBase;

public abstract class EmailServicesException : SystemException
{
    protected EmailServicesException(string message) : base(message)
    { }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
