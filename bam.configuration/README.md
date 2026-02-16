# bam.configuration

Unified configuration management with multiple provider strategies and file persistence.

## Overview

`bam.configuration` provides a comprehensive configuration framework for BAM applications. At its core is the `ConfigurationResolver`, a partial class that resolves configuration values from multiple sources in priority order: .NET Core `IConfiguration`, default configuration files (`ConfigurationManager.AppSettings`), BAM `Config.AppSettings`, BAM environment variables, default values, and remote configuration services. This layered approach ensures that settings are always resolved from the most specific source available.

The library includes several configuration provider implementations (`DefaultConfigurationProvider`, `EnvironmentConfigurationProvider`, `CompositeConfigurationProvider`) that implement `IConfigurationProvider` to retrieve and store key-value application settings. The `Configurable` base class and `IConfigurer`/`IConfigurable` interfaces provide a pattern for objects that need their properties populated from external configuration.

Beyond settings resolution, the library defines data path abstractions (`DataPath`, `ProcessDataPath`, `UserProfileDataPath`, `CurrentDirectoryDataPath`) for consistent file system organization, a `FilePersistable` base class supporting YAML/JSON/XML serialization, and a rich set of interfaces for core services including application registration, user management, authentication, and service proxy communication. These interfaces establish contracts consumed by higher-level BAM modules.

## Key Classes

| Class | Description |
|---|---|
| `ConfigurationResolver` | Singleton that resolves configuration values from multiple sources (IConfiguration, AppSettings, environment variables, remote service) with fallback priority. |
| `CompositeConfigurationProvider` | Aggregates multiple `IConfigurationProvider` instances, merging their configuration values and raising conflict events on key collisions. |
| `DefaultConfigurationProvider` | Reads configuration from `ConfigurationManager.AppSettings` (classic .NET config files). Singleton. |
| `EnvironmentConfigurationProvider` | Reads/writes configuration from/to process environment variables. |
| `Configurable` | Abstract base class for objects that can be configured via an `IConfigurer` or by copying properties from a configuration object. Validates required properties. |
| `DefaultConfigurer` | Configures `IConfigurable` instances using `DefaultConfiguration` app settings. |
| `FilePersistable` | Abstract base class for objects that can be saved/loaded to YAML, JSON, or XML files. Uses universal deterministic IDs for file naming. |
| `DataPath` | Abstract base class providing file system operations (read, write, path resolution) relative to a root directory. |
| `ProcessDataPath` | `DataPath` rooted at a dot-prefixed directory next to the current executable. |
| `UserProfileDataPath` | `DataPath` rooted in the user's home directory under a dot-prefixed executable name. |
| `CurrentDirectoryDataPath` | `DataPath` rooted in the current working directory under a dot-prefixed executable name. |
| `DefaultConfigurationApplicationNameProvider` | Resolves application name from the `ApplicationName` app setting. |
| `EnvironmentApplicationNameProvider` | Resolves application name from the `BAM_APPLICATION_NAME` environment variable. |
| `ServiceRegistryFile` | Describes a file containing interface-to-type mappings for dependency injection. |
| `Validate` | Convenience class for checking that required properties are set on `IHasRequiredProperties` implementations. |
| `ICoreClient` | Interface defining the full API of a BAM core services client (authentication, HMAC keys, proxy generation, login/signup). |
| `IUserRegistry` | Interface for user account management (signup, login, password reset, roles, email confirmation). |
| `ICoreConfigurationProvider` | Extended configuration provider with machine-level, application-level, and common settings. |
| `IServiceProxyClient` | Interface for invoking remote service methods via HTTP GET/POST with argument encoding. |

## Dependencies

### Project References
- `bam.base` -- core framework types, extension methods, reflection utilities, logging interfaces

### Package References
- `YamlDotNet` 16.3.0 -- YAML serialization/deserialization for `FilePersistable`
- `Newtonsoft.Json` 13.0.4 -- JSON serialization for `FilePersistable` and configuration files

## Target Framework
- `net10.0`

## Usage Examples

### Resolving a configuration value with fallback
```csharp
// Initialize from ASP.NET Core configuration
ConfigurationResolver.Startup(builder.Configuration);

// Resolve a value from the first available source
ConfigurationValue dbConn = ConfigurationResolver.Current["ConnectionString", "Server=localhost;Database=mydb"];
string connectionString = dbConn; // implicit conversion to string
```

### Using the Configurable pattern
```csharp
public class MyAppConfig : Configurable
{
    public override string[] RequiredProperties { get; set; } = new[] { "ApiKey", "BaseUrl" };
    public string ApiKey { get; set; }
    public string BaseUrl { get; set; }
}

var config = new MyAppConfig();
config.Configure(new DefaultConfigurer()); // Properties populated from app settings
```

### File persistence with FilePersistable
```csharp
public class MySettings : FilePersistable
{
    public string Name { get; set; }
    public int Timeout { get; set; }

    public override ulong GetUniversalDeterministicId() => (ulong)Name.GetHashCode();
}

var settings = new MySettings { Name = "MyApp", Timeout = 30, Format = SerializationFormat.Yaml };
settings.Save("/path/to/settings.yaml");

var loaded = FilePersistable.Load<MySettings>("/path/to/settings.yaml");
```

### Using DataPath for file operations
```csharp
IDataPath dataPath = ProcessDataPath.Current;
dataPath.WriteFile("content here", "config.yaml", "settings");
string content = dataPath.ReadFile("config.yaml", "settings");
bool exists = dataPath.FileExists("config.yaml", "settings");
```

### Reading configuration from environment variables
```csharp
var envProvider = new EnvironmentConfigurationProvider();
Dictionary<string, string> config = envProvider.GetApplicationConfiguration("MyApp");
```

## Known Gaps / Not Yet Implemented

- **ConfigurationResolver.configurationService**: The partial class `ConfigurationResolver` has a TODO comment to "add configurationService" -- the remote configuration service integration field is not yet wired up.
- **IYamlFilePersistable**: A TODO in `IFilePersistable` notes the intent to create a specialized `IYamlFilePersistable` inheriting interface, which does not yet exist.
- **ICoreClient.LocalCoreRegistryRepository**: Marked with a TODO to rename to `LocalApplicationRegistrationRepository`.
- **UNKNOWN application handling**: `ConfigurationResolver.FromService` has a TODO to account for the UNKNOWN application name case when calling the configuration service.
- **ApplicationConfigurationProvider**: Commented out in `CompositeConfigurationProvider` constructor; integration with a core client for remote configuration is not active.
- **Configuration folder excluded**: The `Configuration\` subfolder is excluded from compilation via the .csproj, indicating code there may be legacy or in-progress.
