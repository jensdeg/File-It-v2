using UserServiceAPI.Interfaces;
using UserServiceAPI.Models;

namespace UserServiceAPI.Repos
{
    public class MockRepo : iUserRepo
    {
        private List<User> _users;
        public MockRepo(int userCount)
        {
            _users = new List<User>();
            for (int i = 0; i < userCount; i++) 
            {
                User user = new User();
                user.Id = Guid.NewGuid();
                user.Name = "user" + i.ToString();
                user.Email = "email" + i.ToString();
                user.Password = "password" + i.ToString();
                _users.Add(user);
            }
        }

        public void CreateUser(User user)
        {
            _users.Add(user);
        }

        public void DeletUser(User user)
        {
            throw new NotImplementedException();
        }

        public User? GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
