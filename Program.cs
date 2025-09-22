using InertiaCore.Extensions;
using Microsoft.AspNetCore.Identity;
using PingCRM.Data;
using PingCRM.Extensions;
using PingCRM.Middleware;
using PingCRM.Models;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Configure logging to suppress HTTPS development certificate warnings
builder.Logging.AddFilter("Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServer", LogLevel.Error);

// Add database services
builder.Services.AddDatabaseServices(builder.Configuration);

// Add Identity services
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Configure authentication
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";
    options.LogoutPath = "/logout";
    options.AccessDeniedPath = "/login";
    options.Cookie.Name = "PingCRM.Auth";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
});

// https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-9.0
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    var forwardedHeadersConfig = builder.Configuration.GetSection("ForwardedHeaders");

    // Set forwarded headers
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

    // Configure forward limit if specified
    var forwardLimit = forwardedHeadersConfig.GetValue<int?>("ForwardLimit");
    if (forwardLimit.HasValue)
    {
        options.ForwardLimit = forwardLimit.Value;
    }

    // Configure custom header name if specified
    var customHeaderName = forwardedHeadersConfig.GetValue<string>("ForwardedForHeaderName");
    if (!string.IsNullOrEmpty(customHeaderName))
    {
        options.ForwardedForHeaderName = customHeaderName;
    }

    // Add known proxies from configuration
    var knownProxies = forwardedHeadersConfig.GetSection("KnownProxies").Get<string[]>();
    if (knownProxies != null)
    {
        foreach (var proxy in knownProxies)
        {
            if (IPAddress.TryParse(proxy.Trim(), out var ipAddress))
            {
                options.KnownProxies.Add(ipAddress);
            }
        }
    }
});

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddSessionStateTempDataProvider();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "PingCRM.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddInertia();
builder.Services.AddViteHelper();

// Configure CSRF/Antiforgery protection
builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
    app.UseForwardedHeaders();
}

app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseInertia();
app.UseMiddleware<CsrfMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<HandleInertiaRequests>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

// Initialize database
await app.InitializeDatabaseAsync();

app.Run();
