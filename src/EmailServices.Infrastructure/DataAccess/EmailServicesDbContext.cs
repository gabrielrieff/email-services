using EmailServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailServices.Infrastructure.DataAccess;

internal class EmailServicesDbContext : DbContext
{
    public EmailServicesDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<SmtpConfiguration> StmpConfigurations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
