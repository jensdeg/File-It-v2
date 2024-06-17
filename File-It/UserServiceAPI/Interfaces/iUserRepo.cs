using Microsoft.AspNetCore.Mvc;
using UserServiceAPI.Models;

namespace UserServiceAPI.Interfaces
{
    public interface iUserRepo
    {
        public IEnumerable<User> GetUsers();
        public User? GetUserById(Guid id);
        public void DeletUser(User user);  
        public void CreateUser(User user);
        public void UpdateUser(User user);
    }
}
