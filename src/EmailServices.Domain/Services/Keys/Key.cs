namespace EmailServices.Domain.Services.Key;
public interface Key
{
    string GeneratorApiKey(int size = 32);
}
