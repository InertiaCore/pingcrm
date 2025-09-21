using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PingCRM.Models;

namespace PingCRM.Wasm;

public partial class Program
{
    private static IServiceProvider? _serviceProvider;
    private static ILogger<Program>? _logger;

    public static async Task Main(string[] args)
    {
        // Initialize the .NET runtime for WebAssembly
        Console.WriteLine("Initializing PingCRM WASM runtime...");

        var builder = Host.CreateDefaultBuilder(args);

        // Configure services for WASM environment
        builder.ConfigureServices((context, services) =>
        {
            // Add HTTP client for external API calls
            services.AddHttpClient();

            // Add JSON serialization
            services.Configure<JsonSerializerOptions>(options =>
            {
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.WriteIndented = false;
            });

            // Add logging
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.SetMinimumLevel(LogLevel.Warning);
            });
        });

        var host = builder.Build();
        _serviceProvider = host.Services;
        _logger = _serviceProvider.GetRequiredService<ILogger<Program>>();

        _logger.LogInformation("PingCRM WASM runtime initialized successfully");

        // In WASM environment, we don't need database initialization
        _logger.LogInformation("WASM environment ready - no database initialization needed");

        await host.RunAsync();
    }


    /// <summary>
    /// JavaScript interop method for handling HTTP requests
    /// </summary>
    [JSExport]
    public static async Task<string> HandleHttpRequest(string method, string path, string headersJson, string body)
    {
        try
        {
            if (_serviceProvider == null)
            {
                return JsonSerializer.Serialize(new
                {
                    statusCode = 500,
                    headers = new Dictionary<string, string> { ["Content-Type"] = "text/plain" },
                    body = "Service provider not initialized"
                });
            }

            using var scope = _serviceProvider.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            logger.LogDebug("Processing {Method} request to {Path}", method, path);

            // Parse headers
            var headers = JsonSerializer.Deserialize<Dictionary<string, string>>(headersJson) ?? new();

            // Route the request based on path
            var response = await RouteRequest(scope.ServiceProvider, method, path, headers, body);

            logger.LogDebug("Request processed successfully with status {StatusCode}", response.StatusCode);

            return JsonSerializer.Serialize(new
            {
                statusCode = response.StatusCode,
                headers = response.Headers,
                body = response.Body
            });
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error processing HTTP request: {Method} {Path}", method, path);

            return JsonSerializer.Serialize(new
            {
                statusCode = 500,
                headers = new Dictionary<string, string> { ["Content-Type"] = "application/json" },
                body = JsonSerializer.Serialize(new { error = "Internal server error", message = ex.Message })
            });
        }
    }

    private static async Task<HttpResponseData> RouteRequest(
        IServiceProvider serviceProvider,
        string method,
        string path,
        Dictionary<string, string> headers,
        string body)
    {
        // Simple routing for WASM environment
        var pathSegments = path.TrimStart('/').Split('/');

        return pathSegments[0].ToLowerInvariant() switch
        {
            "" or "dashboard" => await HandleDashboard(serviceProvider),
            "login" => await HandleAuth(serviceProvider, method, body),
            "logout" => await HandleLogout(serviceProvider),
            "users" => await HandleUsers(serviceProvider, method, pathSegments, body),
            "organizations" => await HandleOrganizations(serviceProvider, method, pathSegments, body),
            "contacts" => await HandleContacts(serviceProvider, method, pathSegments, body),
            "api" => await HandleApi(serviceProvider, method, pathSegments, headers, body),
            _ => await HandleStaticFile(path)
        };
    }

    private static async Task<HttpResponseData> HandleDashboard(IServiceProvider serviceProvider)
    {
        // Return dashboard data
        return new HttpResponseData
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string> { ["Content-Type"] = "application/json" },
            Body = JsonSerializer.Serialize(new { page = "Dashboard", data = new { } })
        };
    }

    private static async Task<HttpResponseData> HandleAuth(IServiceProvider serviceProvider, string method, string body)
    {
        if (method == "POST")
        {
            // Handle login
            var loginData = JsonSerializer.Deserialize<LoginRequest>(body);
            // Implement authentication logic
            return new HttpResponseData
            {
                StatusCode = 200,
                Headers = new Dictionary<string, string> { ["Content-Type"] = "application/json" },
                Body = JsonSerializer.Serialize(new { success = true })
            };
        }

        // Return login page
        return new HttpResponseData
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string> { ["Content-Type"] = "application/json" },
            Body = JsonSerializer.Serialize(new { page = "Login" })
        };
    }

    private static async Task<HttpResponseData> HandleLogout(IServiceProvider serviceProvider)
    {
        return new HttpResponseData
        {
            StatusCode = 302,
            Headers = new Dictionary<string, string> { ["Location"] = "/login" },
            Body = ""
        };
    }

    private static async Task<HttpResponseData> HandleUsers(IServiceProvider serviceProvider, string method, string[] pathSegments, string body)
    {
        // Implement user CRUD operations
        return new HttpResponseData
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string> { ["Content-Type"] = "application/json" },
            Body = JsonSerializer.Serialize(new { page = "Users", method, data = new { } })
        };
    }

    private static async Task<HttpResponseData> HandleOrganizations(IServiceProvider serviceProvider, string method, string[] pathSegments, string body)
    {
        // Implement organization CRUD operations
        return new HttpResponseData
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string> { ["Content-Type"] = "application/json" },
            Body = JsonSerializer.Serialize(new { page = "Organizations", method, data = new { } })
        };
    }

    private static async Task<HttpResponseData> HandleContacts(IServiceProvider serviceProvider, string method, string[] pathSegments, string body)
    {
        // Implement contact CRUD operations
        return new HttpResponseData
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string> { ["Content-Type"] = "application/json" },
            Body = JsonSerializer.Serialize(new { page = "Contacts", method, data = new { } })
        };
    }

    private static async Task<HttpResponseData> HandleApi(IServiceProvider serviceProvider, string method, string[] pathSegments, Dictionary<string, string> headers, string body)
    {
        // Handle API endpoints
        return new HttpResponseData
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string> { ["Content-Type"] = "application/json" },
            Body = JsonSerializer.Serialize(new { api = true, endpoint = string.Join("/", pathSegments) })
        };
    }

    private static async Task<HttpResponseData> HandleStaticFile(string path)
    {
        // Serve static files (CSS, JS, images)
        var extension = Path.GetExtension(path).ToLowerInvariant();
        var contentType = extension switch
        {
            ".css" => "text/css",
            ".js" => "application/javascript",
            ".png" => "image/png",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".svg" => "image/svg+xml",
            ".ico" => "image/x-icon",
            _ => "text/plain"
        };

        return new HttpResponseData
        {
            StatusCode = 404,
            Headers = new Dictionary<string, string> { ["Content-Type"] = contentType },
            Body = "File not found"
        };
    }
}

public class HttpResponseData
{
    public int StatusCode { get; set; }
    public Dictionary<string, string> Headers { get; set; } = new();
    public string Body { get; set; } = "";
}

public class LoginRequest
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public bool Remember { get; set; }
}