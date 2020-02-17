using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DBLayer.Repositories{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ExampleDbContext context) : base(context, context.Users)
        {
        }

        public User GetUserByLastName(string name)
        {
            return (from u in DataSet where u.LastName == name select u).SingleOrDefault();
        }
    }
}