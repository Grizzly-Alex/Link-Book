using Link.Core.Interfaces;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


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

    public static void ApplyMigrations(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<IDbInitializer>().Initialize();

        }
    }
}
