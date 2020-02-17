using DBLayer.Models;
using DBLayer.Repositories;

namespace ServiceLayer.Services{
    public class UserService:IUserService{
        private IUserRepository repository;

        public UserService(IUserRepository repository){
            this.repository = repository;
        }

        public User AddUser(User user)
        {
            this.repository.Create(user);
            return user;
        }

        public User GetById(int userId){
            return this.repository.GetById(userId);
        }

        public User GetUserByLastName(string lastName)
        {
            return this.repository.GetUserByLastName(lastName);
        }
    }
}