using System;

namespace AssetManagement.Web.Models;

public class CheckoutRecord
{
    public int UserId { get; set; }
    public int AssetId { get; set; }
    public DateTime CheckoutTime { get; set; }
}