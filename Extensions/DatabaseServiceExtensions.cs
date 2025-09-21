using Microsoft.EntityFrameworkCore;
using PingCRM.Configuration;
using PingCRM.Data;
using PingCRM.Services;

namespace PingCRM.Extensions;

public static class DatabaseServiceExtensions
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure database options
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));

        // Add database context with dynamic provider selection
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            var databaseOptions = configuration.GetSection(DatabaseOptions.SectionName).Get<DatabaseOptions>();

            if (databaseOptions == null)
            {
                // Fallback to legacy configuration
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection") ?? "Data Source=Data/pingcrm.db");
                return;
            }

            var connectionString = databaseOptions.GetConnectionString();

            switch (databaseOptions.Provider.ToLowerInvariant())
            {
                case "sqlite":
                    options.UseSqlite(connectionString);
                    break;
                case "sqlserver":
                    options.UseSqlServer(connectionString);
                    break;
                case "postgresql":
                    options.UseNpgsql(connectionString);
                    break;
                case "mysql":
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported database provider: {databaseOptions.Provider}");
            }
        });

        // Register database initialization service
        services.AddScoped<IDatabaseInitializationService, DatabaseInitializationService>();

        return services;
    }

    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        try
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbInitService = scope.ServiceProvider.GetRequiredService<IDatabaseInitializationService>();
                await dbInitService.InitializeAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = app.Services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Database initialization failed");

            // For development, continue running even if database fails
            if (app.Environment.IsDevelopment())
            {
                Console.WriteLine($"Database initialization warning: {ex.Message}");
            }
            else
            {
                throw; // Fail fast in production
            }
        }
    }
}