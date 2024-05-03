using Link.Core.Interfaces;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Link.API.Configurations;

public static class ConfigureDb
{
    public static IServiceCollection AddAppDb(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        return services;
    }

    public static async Task ApplyMigrations(this WebApplication app, ILogger logger)
    {
        using var scope = app.Services.CreateScope();

        try
        {
            await scope.ServiceProvider.GetRequiredService<IDbInitializer>().Initialize();

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred initializing the DB.");
        }
    }
}
