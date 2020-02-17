using DBLayer;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;
using System.Diagnostics.CodeAnalysis;

namespace ServiceLayer
{
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}