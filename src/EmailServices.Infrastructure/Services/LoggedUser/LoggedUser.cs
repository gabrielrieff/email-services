using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EmailServices.Domain.Entities;
using EmailServices.Domain.Security.Tokens;
using EmailServices.Domain.Services.LoggedUser;
using EmailServices.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EmailServices.Infrastructure.Services.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly EmailServicesDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;
    
    public LoggedUser(EmailServicesDbContext dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }

    public async Task<Tenant> Get()
    {
        var token = _tokenProvider.TokenOnRequest();

        var tokenHandle = new JwtSecurityTokenHandler();
        
        var jwtSecurityToken = tokenHandle.ReadJwtToken(token);
        
        var identifier = jwtSecurityToken.Claims.First(x => x.Type == ClaimTypes.Sid).Value;
        
        return await _dbContext
            .Tenants
            .AsNoTracking()
            .FirstAsync(x => x.TenantIdentifier == Guid.Parse(identifier));
    }
}