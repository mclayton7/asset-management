using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Web.Services;

public class UserManagementService
{
    private readonly AssetManagementContext _dbContext;
    
    public UserManagementService(AssetManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }
}