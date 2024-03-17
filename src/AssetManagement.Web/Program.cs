using AssetManagement.Web;
using AssetManagement.Web.Components;
using AssetManagement.Web.Models;
using AssetManagement.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<AssetManagementContext>(opt =>
    opt.UseSqlite($"Data Source={nameof(AssetManagementContext.DbPath)}.db"));

builder.Services.AddScoped<UserManagementService>();
builder.Services.AddScoped<AssetManagementService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

var app = builder.Build();


// This section sets up and seeds the database. Seeding is NOT normally
// handled this way in production. The following approach is used in this
// sample app to make the sample simpler. The app can be cloned. The
// connection string is configured. The app can be run.
await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<AssetManagementContext>>();
await DatabaseUtility.EnsureDbCreatedAndSeedWithCountOfAsync(options);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
