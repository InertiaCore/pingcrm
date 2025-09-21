# Ping CRM (powered by InertiaCore)

A demo application to illustrate how Inertia.js works.

![](https://raw.githubusercontent.com/inertiacore/pingcrm/master/screenshot.png)

## Installation

Clone the repo locally:

```sh
git clone https://github.com/inertiacore/pingcrm.git pingcrm
cd pingcrm
```

Install .NET dependencies:

```sh
dotnet restore
```

Install NPM dependencies:

```sh
npm ci
```

Build assets:

```sh
npm run dev
```

Run database migrations:

```sh
dotnet ef database update
```

Run the dev server (the output will give the address):

```sh
dotnet run
```

You're ready to go! Visit Ping CRM in your browser, and login with:

- **Username:** johndoe@example.com
- **Password:** secret

## Running tests

To run the Ping CRM tests, run:

```
dotnet test
```

## Configuration

### Environment Variables and appsettings.json Mapping

All configuration options can be set via environment variables that override values in `appsettings.json`. Environment variables follow the pattern `Section__Property` (note the double underscore).

#### Database Configuration

| appsettings.json                        | Environment Variable                      | Description                                                        |
| --------------------------------------- | ----------------------------------------- | ------------------------------------------------------------------ |
| `Database:Provider`                     | `Database__Provider`                      | Database provider: `Sqlite`, `SqlServer`, `PostgreSQL`, or `MySQL` |
| `Database:ConnectionStrings:Sqlite`     | `Database__ConnectionStrings__Sqlite`     | SQLite connection string                                           |
| `Database:ConnectionStrings:SqlServer`  | `Database__ConnectionStrings__SqlServer`  | SQL Server connection string                                       |
| `Database:ConnectionStrings:PostgreSQL` | `Database__ConnectionStrings__PostgreSQL` | PostgreSQL connection string                                       |
| `Database:ConnectionStrings:MySQL`      | `Database__ConnectionStrings__MySQL`      | MySQL connection string                                            |

#### Forwarded Headers Configuration (for Proxy/Load Balancer scenarios)

Add the following to your `appsettings.json` to configure forwarded headers:

```json
{
  "ForwardedHeaders": {
    "ForwardLimit": 2,
    "KnownProxies": ["127.0.10.1", "192.168.1.100"],
    "ForwardedForHeaderName": "X-Forwarded-For"
  }
}
```

| appsettings.json                          | Environment Variable                                                           | Description                                                     |
| ----------------------------------------- | ------------------------------------------------------------------------------ | --------------------------------------------------------------- |
| `ForwardedHeaders:ForwardLimit`           | `ForwardedHeaders__ForwardLimit`                                               | Number of proxies to trust (default: 1)                         |
| `ForwardedHeaders:KnownProxies`           | `ForwardedHeaders__KnownProxies__0`, `ForwardedHeaders__KnownProxies__1`, etc. | Array of trusted proxy IP addresses                             |
| `ForwardedHeaders:ForwardedForHeaderName` | `ForwardedHeaders__ForwardedForHeaderName`                                     | Custom header name for forwarded-for (default: X-Forwarded-For) |

#### Logging Configuration

| appsettings.json             | Environment Variable           | Description                   |
| ---------------------------- | ------------------------------ | ----------------------------- |
| `Logging:LogLevel:Default`   | `Logging__LogLevel__Default`   | Default log level             |
| `Logging:LogLevel:Microsoft` | `Logging__LogLevel__Microsoft` | Microsoft namespace log level |

#### Other Configuration

| appsettings.json | Environment Variable | Description                                      |
| ---------------- | -------------------- | ------------------------------------------------ |
| `AllowedHosts`   | `AllowedHosts`       | Semicolon-separated list of allowed host headers |
