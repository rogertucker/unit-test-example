using System;
using System.Diagnostics.CodeAnalysis;
using DBLayer.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DBLayer{
    [ExcludeFromCodeCoverage]
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public string CurrentDirectory { get; set; }

        public DependencyResolver()
        {
            // Set up Dependency Injection
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {

            // Register env and config services
            services.AddTransient<IEnvironmentService, EnvironmentService>();
   
            services.AddTransient<IConfigurationService, ConfigurationService>
                (provider => new ConfigurationService(provider.GetService<IEnvironmentService>())
                {
                    CurrentDirectory = CurrentDirectory
                });
    
            // Register DbContext class
            services.AddTransient(provider =>
            {
                var configService = provider.GetService<IConfigurationService>();
                
                var connectionString = configService.GetConfiguration().GetConnectionString("unit-test-example");
                var optionsBuilder = new DbContextOptionsBuilder<ExampleDbContext>();
                optionsBuilder.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("DBLayer"));
                return new ExampleDbContext(optionsBuilder.Options);
            });
        }
    }
}