using EmailServices.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmailServices.Infrastructure.Migrations;

public class DataBaseMigration 
{ 

    public static async Task MigrateDataBase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<EmailServicesDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
