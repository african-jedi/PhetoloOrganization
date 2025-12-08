using System;
using Phetolo.Math28.Application.Interface;
using Phetolo.Math28.Application.UseCases;
using Phetolo.Math28.Infrastructure.Service;
using Phetolo.Math28.PuzzleGenerator;

namespace Phetolo.Math28.API;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddScoped<IPuzzleGeneratorService, PuzzleGeneratorService>();
        services.AddScoped<GetTodayPuzzleUseCase>();
        services.AddScoped<Generator>();
    }
}
