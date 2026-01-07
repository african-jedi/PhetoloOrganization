# Phetolo Organization Projects

This repository contains the main website project and Math28 game project.


The Math28 solution consists of the following components:

1. **Frontend**: Angular (version 20) single-page application  
2. **Backend API**: .NET 9 ASP.NET Core Web API  
3. **Puzzle Generator Service**: .NET 9 ASP.NET Core Web API (separate microservice)  
4. **Inter-service Communication**: RabbitMQ for asynchronous messaging between microservices  
5. **Database**: PostgreSQL  
6. **Caching**: Redis for distributed caching  
7. **Real-time Communication**: SignalR for real-time notifications

## Core Nuget packages used in the .net 9 core project

### 1. MediatR

The project uses the **MediatR** package to implement the **CQRS (Command Query Responsibility Segregation)** pattern and decouple the application logic from the presentation layer.

Controllers do not directly reference or invoke command or query handlers. Instead, they send commands and queries through MediatR, which is responsible for locating and executing the appropriate handler. This approach improves separation of concerns, testability, and maintainability of the codebase.

### 2. Entity Framework Core with PostgreSQL (`Npgsql.EntityFrameworkCore.PostgreSQL`)

The Math28 application uses **PostgreSQL (version 17)** as its database. **Entity Framework Core** was selected as the ORM because it integrates well with PostgreSQL through the `Npgsql.EntityFrameworkCore.PostgreSQL` provider.

A **code-first** approach was chosen since there was no existing database schema. This allows the domain models to define the database structure, with migrations used to manage schema changes over time.

### 3. Redis (`Microsoft.Extensions.Caching.StackExchangeRedis`)

The project uses the official Redis integration package, **`Microsoft.Extensions.Caching.StackExchangeRedis`**, to implement distributed caching.

A **cache-aside** strategy is applied, where the application explicitly controls when data is read from or written to the cache. This allows selective caching of API responses that have the greatest impact on performance, while keeping the caching logic simple and predictable.
