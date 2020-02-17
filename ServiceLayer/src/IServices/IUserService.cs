using DBLayer.Models;

namespace ServiceLayer.Services
{
    public interface IUserService{
        User GetById(int userId);

        User GetUserByLastName(string lastName);
        User AddUser(User user);
    }
}