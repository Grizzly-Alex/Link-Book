using Link.API.Utilities;
using Link.Application.Utilities;
using Link.Core.Interfaces;
using Link.Infrastructure.Repositories;

namespace Link.API.Configurations;

public static class ConfigureServices
{
    public static IServiceCollection AddAllAppServices(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandler>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped(typeof(IRepository<>), typeof(LinkCategoryRepository));
        services.AddScoped(typeof(IRepository<>), typeof(UserLinkRepository));
        return services;
    }
}
