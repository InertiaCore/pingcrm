namespace PingCRM.Configuration;

public class DatabaseOptions
{
    public const string SectionName = "Database";

    public required string Provider { get; set; }
    public required Dictionary<string, string> ConnectionStrings { get; set; }

    public string GetConnectionString()
    {
        return ConnectionStrings.TryGetValue(Provider, out var connectionString)
            ? connectionString
            : throw new InvalidOperationException($"Connection string for provider '{Provider}' not found.");
    }
}

public enum DatabaseProvider
{
    Sqlite,
    SqlServer,
    PostgreSQL,
    MySQL
}