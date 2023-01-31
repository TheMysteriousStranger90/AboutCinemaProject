using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace WebAPI.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        
        services.AddDbContext<AboutCinemaProjectContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });
        
        services.AddSingleton<IConnectionMultiplexer>(c => 
        {
            var options = ConfigurationOptions.Parse(config.GetConnectionString("Redis"));
            return ConnectionMultiplexer.Connect(options);
        });
        
        
        
        
        
        
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy => 
            {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
            });
        });

        return services;
    }
}