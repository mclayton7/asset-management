using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Web.Models;

namespace AssetManagement.Web.Components.Pages;

public partial class ViewInventory
{
    private List<Asset>? _assets;

    protected override async Task OnInitializedAsync()
    {
        // Simulate asynchronous loading to demonstrate a loading indicator
        await Task.Delay(500);
        _assets = await AssetManagementService.GetAllAssets();
    }
}