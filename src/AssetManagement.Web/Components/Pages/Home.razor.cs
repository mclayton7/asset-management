namespace AssetManagement.Web.Components.Pages;

public partial class Home
{
    private void HandleClick(string slug)
    {
        NavigationManager.NavigateTo(slug);
    }
}