using System.Collections.Generic;

namespace AssetManagement.Web.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BadgeId { get; set; }
    public string Email { get; set; }

    public ICollection<Asset> Assets { get; } = new List<Asset>();
}