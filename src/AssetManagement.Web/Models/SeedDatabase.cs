using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.Web.Models;

// Generates desired number of random contacts.
public class SeedDatabase
{
    private static IEnumerable<User> CreateUsers()
    {
        return
        [
            new User()
            {
                FirstName = "Mac",
                LastName = "Clayton",
                Email = "mckenzie.clayton@i3-corps.com",
                BadgeId = "1234"
            }
        ];
    }

    private static IEnumerable<Asset> CreateAssets()
    {
        return
        [
            new Asset()
            {
                Name = "MagicLeap 2",
                BarcodeId = "5678"
            }
        ];
    }

    public async Task SeedDatabaseWithContactCountOfAsync(AssetManagementContext context)
    {
        context.Users?.AddRange(CreateUsers());
        context.Assets?.AddRange(CreateAssets());
        await context.SaveChangesAsync();
    }
}
