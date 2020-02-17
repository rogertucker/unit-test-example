using System.Diagnostics.CodeAnalysis;
using DBLayer;
using DBLayer.Repositories;
using DBLayer.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DBLayer
{
    [ExcludeFromCodeCoverage]
    public static class IRepositoryCollectionExtension
    {
        public static string CurrentDirectory { get; set; }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>
            (provider =>
            {
                return new ConfigurationService(provider.GetService<IEnvironmentService>())
                {
                    CurrentDirectory = CurrentDirectory
                };
            }
            );

            services.AddScoped<ExampleDbContext>(provider =>
            {
                var configService = provider.GetService<IConfigurationService>();
                var connectionString = configService.GetConfiguration().GetConnectionString("unit-test-example");
                var optionsBuilder = new DbContextOptionsBuilder<ExampleDbContext>();
                optionsBuilder.UseSqlServer(connectionString);
                return new ExampleDbContext(optionsBuilder.Options);
            });


            services.AddTransient<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}