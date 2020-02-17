using DBLayer;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace DBLayer
{
    [ExcludeFromCodeCoverage]
    public class DbContextFactory : IDesignTimeDbContextFactory<ExampleDbContext>
    {
        public ExampleDbContext CreateDbContext(string[] args)
        {
            return GetDBContext();
        }

        public ExampleDbContext GetDBContext(){
            var resolver = new DependencyResolver
            {
                CurrentDirectory = Path.Combine(Directory.GetCurrentDirectory())
            };
            
            return resolver.ServiceProvider.GetService(typeof(ExampleDbContext)) as ExampleDbContext;
        }
    }

}