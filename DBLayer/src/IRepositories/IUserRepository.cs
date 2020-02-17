using DBLayer.Models;

namespace DBLayer.Repositories
{
    
    public interface IUserRepository: IBaseRepository<User>
    {
        User GetUserByLastName(string name);
    }
}