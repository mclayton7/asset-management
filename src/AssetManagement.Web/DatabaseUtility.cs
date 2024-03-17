using System.Threading.Tasks;
using AssetManagement.Web.Models;
using Microsoft.Extensions.Logging;

namespace AssetManagement.Web;

using Microsoft.EntityFrameworkCore;

public static class DatabaseUtility
{
    // Method to see the database. Should not be used in production: demo purposes only.
    // options: The configured options.
    // count: The number of contacts to seed.
    public static async Task EnsureDbCreatedAndSeedWithCountOfAsync(DbContextOptions<AssetManagementContext> options)
    {
        // Empty to avoid logging while inserting (otherwise will flood console).
        var factory = new LoggerFactory();
        var builder = new DbContextOptionsBuilder<AssetManagementContext>(options)
            .UseLoggerFactory(factory);

        using var context = new AssetManagementContext();
        // Result is true if the database had to be created.
        if (await context.Database.EnsureCreatedAsync())
        {
            var seed = new SeedDatabase();
            await seed.SeedDatabaseWithContactCountOfAsync(context);
        }
    }
}
