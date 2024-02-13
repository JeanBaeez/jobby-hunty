using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using JobHunt.Areas.Identity;
using JobHunt.Data;
using Syncfusion.Blazor;
using MudBlazor.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString), ServiceLifetime.Transient);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<JobHunt.Services.Job.IJobService, JobHunt.Services.Job.JobService>();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt7QHFqUUdrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRbQl9iS39bdUxgXnxednw=;Mgo+DSMBPh8sVXJwS0d+WFBPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9nSXxSdERrWnZdd3dXRGU=;ORg4AjUWIQA/Gnt2UVhhQlVFfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTX5Rd0diUXxXc3NWRWhd;Mgo+DSMBMAY9C3t2UVhhQlVFfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTX5Rd0diUXxXc3NWQ2Nb;MzA5ODUyOEAzMjM0MmUzMDJlMzBMTzl4bUFzTkt5YmtCeFVvNjZ6SHpJZktjVURCNzNJYnZJK3lJeFJwNVBVPQ==;MzA5ODUyOUAzMjM0MmUzMDJlMzBGSGdXS3ZQVHJmemx6aXBPTmZjT1VORnIramIvb3kzblZnNkhXRFgzL1BZPQ==");
builder.Services.AddMudServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();