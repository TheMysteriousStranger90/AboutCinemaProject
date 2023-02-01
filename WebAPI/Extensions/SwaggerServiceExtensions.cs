using Microsoft.OpenApi.Models;

namespace WebAPI.Extensions;

public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "AboutCinemaProject",
                Description = "API provides work with cinema base.",
                Contact = new OpenApiContact
                {
                    Name = "Bohdan Harabadzhyu",
                    Email = "bohdan.harabadzhyu@yandex.ru",
                    Url = new Uri("https://bohdan-harabadzhyu-homepage.vercel.app"),
                }
            });

            var securitySchema = new OpenApiSecurityScheme
            {
                Description = "JWT Auth Bearer Scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            c.AddSecurityDefinition("Bearer", securitySchema);
            var securityRequirement = new OpenApiSecurityRequirement{{securitySchema, new[] {"Bearer"}}};
            c.AddSecurityRequirement(securityRequirement);
        });

        return services;
    }
    
    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
