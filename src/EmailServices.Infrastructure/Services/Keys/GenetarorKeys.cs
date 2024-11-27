using System.Security.Cryptography;
using EmailServices.Domain.Services.Keys;

namespace EmailServices.Infrastructure.Services.Keys;

public class GenetarorKeys : IKey
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
