using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AssetManagement.Web.Components.Pages;

public partial class Admin
{
    private List<ApplicationUser>? _users;
    private List<Asset>? _assets;
    private string _authMessage = "The user is NOT authenticated.";

    [CascadingParameter] private Task<AuthenticationState>? authenticationState { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (authenticationState is not null)
        {
            var authState = await authenticationState;
            var user = authState?.User;

            if (user?.Identity is not null && user.Identity.IsAuthenticated)
            {
                _authMessage = $"{user.Identity.Name} is authenticated.";
            }
        }

        // Simulate asynchronous loading to demonstrate a loading indicator
        await Task.Delay(500);

        _users = await UserManagementService.GetAllUsers();
        _assets = await AssetManagementService.GetAllAssets();
    }
}