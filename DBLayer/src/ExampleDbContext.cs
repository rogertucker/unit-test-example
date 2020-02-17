using System.Diagnostics.CodeAnalysis;
using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBLayer
{
    [ExcludeFromCodeCoverage]
    public partial class ExampleDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public ExampleDbContext()
        {
        }

        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public virtual void SetEntityState(BaseModel model, EntityState state)
        {
            Entry(model).State = state;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new EnumToStringConverter<PhoneType>();

            modelBuilder
                .Entity<PhoneNumber>()
                .Property(e => e.PhoneType)
                .HasConversion(converter);
        }
    }
}
