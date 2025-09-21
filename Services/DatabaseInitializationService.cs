using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PingCRM.Configuration;
using PingCRM.Data;

namespace PingCRM.Services;

public interface IDatabaseInitializationService
{
    Task InitializeAsync();
    Task<bool> CanConnectAsync();
}

public class DatabaseInitializationService : IDatabaseInitializationService
{
    private readonly ApplicationDbContext _context;
    private readonly DatabaseOptions _databaseOptions;
    private readonly ILogger<DatabaseInitializationService> _logger;

    public DatabaseInitializationService(
        ApplicationDbContext context,
        IOptions<DatabaseOptions> databaseOptions,
        ILogger<DatabaseInitializationService> logger)
    {
        _context = context;
        _databaseOptions = databaseOptions.Value;
        _logger = logger;
    }

    public async Task<bool> CanConnectAsync()
    {
        try
        {
            return await _context.Database.CanConnectAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to connect to database");
            return false;
        }
    }

    public async Task InitializeAsync()
    {
        try
        {
            _logger.LogInformation("Initializing database with provider: {Provider}", _databaseOptions.Provider);

            // Ensure database exists
            if (_databaseOptions.Provider.ToLowerInvariant() == "sqlite")
            {
                // For SQLite, ensure the directory exists
                var connectionString = _databaseOptions.GetConnectionString();
                var dataSourceMatch = System.Text.RegularExpressions.Regex.Match(connectionString, @"Data Source=([^;]+)");
                if (dataSourceMatch.Success)
                {
                    var dbPath = dataSourceMatch.Groups[1].Value;
                    var directory = Path.GetDirectoryName(dbPath);
                    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                        _logger.LogInformation("Created directory for SQLite database: {Directory}", directory);
                    }
                }
            }

            // Create or update database
            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                _logger.LogInformation("Applying {Count} pending migrations", pendingMigrations.Count());
                await _context.Database.MigrateAsync();
            }
            else if (!await _context.Database.CanConnectAsync())
            {
                _logger.LogInformation("Creating database");
                await _context.Database.EnsureCreatedAsync();
            }

            _logger.LogInformation("Database initialization completed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Database initialization failed");
            throw;
        }
    }
}