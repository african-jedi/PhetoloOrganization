# Serilog
Serilog enables use of structured logging with enrichers. *Enrichers* enables logging of important information such as *MachineName*. *Enrichers* requires additional packages to be added to solution. For example, the `WithMachineName` will only work when `Serilog.Enrichers.Environment` package is working.

### Prerequisite - Install the following packages
1. Serilog Nuget package
```bash
dotnet add package Serilog --version 4.3.0
```

### 1. Serilog
*Serilog* provides advanced logging for .net applications. Serilog shines over standard logging when it comes to instrumentation of complex, distributed and asynchronous applications.

### 2. Serilog.AspNetCore
*Serilog.AspNetCore* is used to add middleware on asp.net pipeline for request logging.

```bash
dotnet add package Serilog.AspNetCore --version 10.0.0
```
### 2. Serilog.Enrichers.Environment
*Serilog.Enrichers.Environment* is used provide information from the execution environment. This information includes: (1) MachineName, (2) EnvironmentUserName, (3) EnvironmentName

```bash
dotnet add package Serilog.Enrichers.Environment
```

### 3. Serilog.Sinks.File
*Serilog.Sinks.File* package is used to log Serilog's to file.

```bash
dotnet add package Serilog.Sinks.File --version 7.0.0
```

### 4. Serilog.Sinks.Console
*Serilog.Sinks.Console* package is used to log Serilog's to console.

```bash
dotnet add package Serilog.Sinks.Console --version 6.1.1
```

### 5. Serilog.Enrichers.CorrelationId
*Serilog.Enrichers.CorrelationId* package is used to log CorrelationId in Serilog's, to track API requests. This is the most commonly used Serilog Enricher with over **36.4 million** downloads.

### Configure Using AppSettings
To configure using AppSettings, add below line which enables logging from file system.

```csharp
builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(context.Configuration));
```

Add the following in the AppSettings:
```json
"Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
    "Enrich": [ "FromLogContext", "WithThreadId", "WithMachineName"],
    "MinimumLevel": "Debug",
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss} [{CorrelationId}] [{Level:u3}] [{MachineName}] {Message:lj}{NewLine}{Exception}"
        }
      },
      {
        "Name": "File",
        "Args": {
          "path": "logs/log-dev-.txt",
          "rollingInterval": "Day",
          "retainedFileCountLimit": 3,
          "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss} [{CorrelationId}] [{Level:u3}] [{MachineName}] {Message:lj}{NewLine}{Exception}"
        }
      }
    ]
  }
```

### Configure Using Code
```csharp
builder.Host.UseSerilog((context, configuration) =>
    configuration
        .WriteTo.Console()
        .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
        .MinimumLevel.Debug()
        .Enrich.FromLogContext()
        .Enrich.WithProperty("Application", "Math28.API"));
```
