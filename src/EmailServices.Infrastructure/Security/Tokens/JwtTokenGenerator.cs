using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmailServices.Domain.Entities;
using EmailServices.Domain.Security.Tokens;
using EmailServices.Infrastructure.Services.LoggedUser;
using Microsoft.IdentityModel.Tokens;

namespace EmailServices.Infrastructure.Security.Tokens;

public class JwtTokenGenerator : IAccessTokenGenerator
{
    private readonly uint _expirationTimeMinutes;
    private readonly string _signingKey;

    public JwtTokenGenerator(uint expirationTimeMinutes, string signingKey)
    {
        _expirationTimeMinutes = expirationTimeMinutes;
        _signingKey = signingKey;

    }

    public string Generate(Tenant tenant)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, tenant.Name),
            new Claim(ClaimTypes.Sid, tenant.TenantIdentifier.ToString()),
        };

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandle = new JwtSecurityTokenHandler();
        
        var securityToken = tokenHandle.CreateToken(tokenDescriptor);
        
        return tokenHandle.WriteToken(securityToken);
    }
    
    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(_signingKey);

        return new SymmetricSecurityKey(key);
    }
}