using System;
using System.Linq;
using DBLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.Tests {
    public class TestDb {
        public TestDb(){
            var optionsBuilder = new DbContextOptionsBuilder<ExampleDbContext>();
                optionsBuilder.UseSqlite("DataSource=:memory:");
                ExampleDbContext context = new ExampleDbContext(optionsBuilder.Options);
                context.Database.OpenConnection();
                context.Database.EnsureCreated();
                Context = context;

        }

        public ExampleDbContext Context { get; set; }

        public void SeedDb (){

            SeedAddresses(Context);
            SeedPhoneNumbers(Context);
            SeedUsers(Context);        
        }

        private void SeedPhoneNumbers(ExampleDbContext context)
        {
            context.Add(new PhoneNumber{
                Number="TestUser1MobilePhone",
                PhoneType=PhoneType.Mobile
            });
            context.SaveChanges();
            context.Add(new PhoneNumber{
                Number="TestUser1HomePhone",
                PhoneType=PhoneType.Home
            });
            context.SaveChanges();

        }

        private void SeedAddresses(ExampleDbContext context)
        {
            context.Add(new Address{
                Address1="User1Address11",
                Address2="User1Address21",
                City="User1City1",
                State="User1State1",
                PostalCode="User1PostalCode1"
            });
            context.SaveChanges();

           context.Add(new Address{
                Address1="User1Address12",
                Address2="User1Address22",
                City="User1City2",
                State="User1State2",
                PostalCode="User1PostalCode2"
            });
            context.SaveChanges();
        }

        private void SeedUsers(ExampleDbContext context)
        {
            context.Add(new User{
                FirstName="Test",
                LastName="User1",
                PhoneNumbers = (from x in context.PhoneNumbers where new int[] {1, 2}.Contains(x.ID) select x).ToList(),
                Addresses = (from x in context.Addresses where new int[] {1, 2}.Contains(x.ID) select x).ToList(),
            });

            context.SaveChanges();


        }
    }
}