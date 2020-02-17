using DBLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.Repositories {
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ExampleDbContext context) : base(context, context.Addresses)
        {
        }
    }
}