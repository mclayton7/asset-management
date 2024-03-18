using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Web.Models;

public class AssetManagementContext : DbContext
{
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Asset> Assets { get; set; }

    public string DbPath { get; }

    public AssetManagementContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "app.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
