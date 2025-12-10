using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Phetolo.Math28.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Order API",
        Version = "v1",
        Description = "A sample API for demonstrating RabbitMQ Producer and Consumer in Web API",
        Contact = new OpenApiContact
        {
            Name = "African Jedi"
        }
    });
});
builder.Services.AddStackExchangeRedisCache(Options =>
{
    Options.Configuration = builder.Configuration.GetConnectionString("Redis");
    Options.InstanceName = "Math28.API_";
});

builder.AddApplicationServices();

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

