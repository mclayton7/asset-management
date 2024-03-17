namespace AssetManagement.Web.Models;

public class Asset
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BarcodeId { get; set; }
    
    public int? UserId { get; set; }
    public User? User { get; set; }
}