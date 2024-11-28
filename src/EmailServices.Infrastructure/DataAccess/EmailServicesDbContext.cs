using EmailServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailServices.Infrastructure.DataAccess;

public class EmailServicesDbContext : DbContext
{
    public EmailServicesDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<SmtpConfiguration> SmtpConfigurations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
