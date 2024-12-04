using EmailServices.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailServices.Api.DataAccess;

public class EmailServicesDContext : DbContext
{
    public EmailServicesDContext(DbContextOptions options) : base(options){}
    
    public DbSet<Email> Emails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}