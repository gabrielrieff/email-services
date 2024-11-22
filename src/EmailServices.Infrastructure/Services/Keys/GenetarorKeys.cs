using EmailServices.Domain.Services.Key;
using System.Security.Cryptography;

namespace EmailServices.Infrastructure.Services.Keys;

public class GenetarorKeys : Key
{
    public string GeneratorApiKey(int size)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] apiKeyBytes = new byte[size];
            rng.GetBytes(apiKeyBytes);

            return Convert.ToBase64String(apiKeyBytes);
        }
    }
}
