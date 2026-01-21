using Alfasoft.ContactManager.Database;
using Microsoft.EntityFrameworkCore;

namespace Alfasoft.ContactManager.Extensions;

public static class AppMigrationsExtensions
{
    public static void RunInitialMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContext>>();

        try
        {
            logger.LogInformation("Running initial database migrations...");
            dbContext.Database.Migrate();
            logger.LogInformation("Database migrations completed.");
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while applying database migrations.");
            throw;
        }
        
    }
}