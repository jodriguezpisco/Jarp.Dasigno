using Microsoft.OpenApi.Models;
using System.Net.NetworkInformation;
using System.Reflection;

namespace Jarp.Dasigno.Api
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Jarp Dasigno Api",
                    Description = "Apis para prueba tecnica Dasigno",
                });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
            });

            return services;
        }
    }
}
