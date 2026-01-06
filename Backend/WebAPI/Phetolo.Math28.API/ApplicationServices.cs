using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Phetolo.Math28.API.Hubs;
using Phetolo.Math28.Application.Interface;
using Phetolo.Math28.Application.UseCases;
using Phetolo.Math28.Core.Interfaces;
using Phetolo.Math28.Infrastructure.Repository;
using Phetolo.Math28.Infrastructure.Service;
using Phetolo.Math28.PuzzleGenerator;
using Phetolo.Math28.PuzzleGenerator.Helper;

namespace Phetolo.Math28.API;

internal static class Extensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPuzzleGeneratorService, PuzzleGeneratorService>();
        // Register the base repository implementation
        services.AddScoped<PuzzleRepository>();
        // Register the decorator that wraps the base implementation
        services.AddScoped<IPuzzleRepository>(provider => 
            new CachedPuzzleRepository(
                provider.GetRequiredService<PuzzleRepository>(), 
                provider.GetRequiredService<IDistributedCache>(),
                provider.GetRequiredService<ILogger<CachedPuzzleRepository>>()));

        services.AddScoped<GetTodayPuzzleUseCase>();
        services.AddScoped<GetNextPuzzleUseCase>();
        services.AddTransient<Generator>();
        services.AddTransient<NumberGeneratorHelper>();

        return services;
    }
}
