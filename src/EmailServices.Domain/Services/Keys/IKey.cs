namespace EmailServices.Domain.Services.Keys;
public interface IKey
{
    string GeneratorApiKey(int size = 32);
}
