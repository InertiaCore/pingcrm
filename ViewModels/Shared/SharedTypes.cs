using TypeGen.Core.TypeAnnotations;

namespace PingCRM.ViewModels.Shared;

/// <summary>
/// User data transfer object for client-side TypeScript generation
/// Maps to the User interface with snake_case properties
/// </summary>
[ExportTsClass]
public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool Owner { get; set; }
    public AccountDto? Account { get; set; }
}

/// <summary>
/// Account data transfer object for client-side TypeScript generation
/// </summary>
[ExportTsClass]
public class AccountDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

/// <summary>
/// Authentication state for Inertia shared props
/// </summary>
[ExportTsClass]
public class AuthDto
{
    public UserDto? User { get; set; }
}

/// <summary>
/// Flash message data for Inertia shared props
/// </summary>
[ExportTsClass]
public class FlashDto
{
    public string? Error { get; set; }
    public string? Success { get; set; }
}

/// <summary>
/// Base shared props that are available on all Inertia pages
/// </summary>
[ExportTsClass]
public class InertiaSharedProps
{
    public required AuthDto Auth { get; set; }
    public FlashDto? Flash { get; set; }
}

/// <summary>
/// Pagination metadata for paginated results
/// </summary>
[ExportTsClass]
public class PaginationMeta
{
    public int CurrentPage { get; set; }
    public int From { get; set; }
    public int LastPage { get; set; }
    public string Path { get; set; } = string.Empty;
    public int PerPage { get; set; }
    public int To { get; set; }
    public int Total { get; set; }
}

/// <summary>
/// Pagination link for navigation
/// </summary>
[ExportTsClass]
public class PaginationLink
{
    public string? Url { get; set; }
    public string Label { get; set; } = string.Empty;
    public bool Active { get; set; }
}

/// <summary>
/// Generic paginated data container
/// </summary>
[ExportTsClass]
public class PaginatedData<T>
{
    public List<T> Data { get; set; } = new();
    public List<PaginationLink> Links { get; set; } = new();
    public PaginationMeta Meta { get; set; } = new();
}

/// <summary>
/// Common search filters used across multiple pages
/// </summary>
[ExportTsClass]
public class SearchFilters
{
    public string? Search { get; set; }
    public string? Trashed { get; set; }
}

/// <summary>
/// User-specific filters extending base search filters
/// </summary>
[ExportTsClass]
public class UserFilters : SearchFilters
{
    public string? Role { get; set; }
}

/// <summary>
/// Create user form data
/// </summary>
[ExportTsClass]
public class CreateUserForm
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Owner { get; set; }
    public object? Photo { get; set; } // File input, nullable
}
