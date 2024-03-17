using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Web.Services;

public class AssetManagementService
{
    private readonly AssetManagementContext _dbContext;
    
    public AssetManagementService(AssetManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Asset>> GetAllAssets()
    {
        return await _dbContext.Assets.ToListAsync();
    }
}