using HealthChecks.UI.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Phetolo.Math28.API;
using Phetolo.Math28.API.Hubs;
using Phetolo.Math28.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Order API",
        Version = "v1",
        Description = "Math28API - used by Angular 19 app",
        Contact = new OpenApiContact
        {
            Name = "African Jedi"
        }
    });
});

builder.Services.AddDbContext<Math28DBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Math28DB"));
});
//builder.EnrichNpgsqlDbContext<Math28DBContext>();

//services.AddMigration<Math28DBContext, Math28DBContextSeed>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Phetolo.Math28.Application.AssemblyReference.Assembly);
});

builder.Services.AddStackExchangeRedisCache(Options =>
{
    Options.Configuration = builder.Configuration.GetConnectionString("Redis");
    Options.InstanceName = "Math28.API_";
}).AddApplicationServices();

builder.Services.AddHealthChecks()
    .AddCheck("Math28API-check", () => HealthCheckResult.Healthy())
    .AddRedis(
        builder.Configuration.GetConnectionString("Redis")!,
        name: "Redis-check",
        failureStatus: HealthStatus.Unhealthy,
        tags: new string[] { "db", "redis" })
    .AddNpgSql(
        builder.Configuration.GetConnectionString("Math28DB")!,
        name: "Math28DB-check",
        healthQuery: "SELECT 1;",
        failureStatus: HealthStatus.Unhealthy,
        tags: new string[] { "db", "sql", "postgresql" });

// Explicitly configure Kestrel to listen on IPv4 0.0.0.0:80  
//builder.WebHost.ConfigureKestrel(serverOptions => serverOptions.ListenAnyIP(80));  

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

    using (IServiceScope scope = app.Services.CreateScope())
    {
        Math28DBContext dbContext = scope.ServiceProvider.GetRequiredService<Math28DBContext>();
        //dbContext.Database.Migrate();
    }
}

app.UseHttpsRedirection();
app.MapHub<WinnerNotificationHub>("/winnerNotificationHub");
app.UseCors("AllowAll");
app.UseRouting();
app.UseEndpoints(endPoints =>
{
    endPoints.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

app.Run();