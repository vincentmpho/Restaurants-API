using Microsoft.OpenApi.Models;
using Restaurants_API.Middlewares;
using Serilog;

namespace Restaurants_API.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentation (this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();
            builder.Services.AddControllers();
            // Add API Explorer for endpoints
            builder.Services.AddEndpointsApiExplorer();
            // Add Swagger generation
            builder.Services.AddSwaggerGen(c =>
            {
                // Define security definition for bearer token
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                // Add security requirement for endpoints
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id ="bearerAuth"
                }
            },
            Array.Empty<string>()
        }
    });
            });


            // Register RequestTimeLoggingMiddleware for logging request times
            builder.Services.AddScoped<RequestTimeLoggingMiddleware>();


            // Configure Serilog for logging
            builder.Host.UseSerilog((context, configuration) =>
                configuration
                    .ReadFrom.Configuration(context.Configuration)
            );

        }

    }
}
