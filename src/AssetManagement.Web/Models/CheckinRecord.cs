using System;

namespace AssetManagement.Web.Models;

public class CheckinRecord
{
    public int UserId { get; set; }
    public int AssetId { get; set; }
    public DateTime CheckinTime { get; set; }
}