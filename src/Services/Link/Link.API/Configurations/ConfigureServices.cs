using Link.API.Utilities;
using Link.Application.Utilities;
using Link.Core.Entities;
using Link.Core.Interfaces;
using Link.Infrastructure.Data;
using Link.Infrastructure.Repositories;


namespace Link.API.Configurations;

public static class ConfigureServices
{
    public static IServiceCollection AddAllAppServices(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandler>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped(typeof(IRepository<LinkCategory>), typeof(LinkCategoryRepository));
        services.AddScoped(typeof(IRepository<UserLink>), typeof(UserLinkRepository));
        services.AddScoped(typeof(IDbInitializer), typeof(Initializer));
        return services;
    }
}