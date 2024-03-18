namespace AssetManagement.Web.Models;

public class Asset
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string BarcodeId { get; set; }
    
    public int? UserId { get; set; }
    public ApplicationUser? User { get; set; }
}