using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using UserServiceAPI.Database.Context;
using UserServiceAPI.Interfaces;
using UserServiceAPI.Models;

namespace UserServiceAPI.Repos
{
    public class UserRepo : iUserRepo
    {
        private readonly UserDBcontext _userDBcontext;

        public UserRepo(UserDBcontext userDBcontext)
        {
            _userDBcontext = userDBcontext;
        }

        public void CreateUser(User user)
        {
            _userDBcontext.users.Add(user);
            _userDBcontext.SaveChanges();
        }

        public void DeletUser(User user)
        {
            //Doesnt work
            _userDBcontext.users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            //probably doesnt work
            _userDBcontext.users.Update(user);
        }

        public User? GetUserById(Guid id)
        {
            return _userDBcontext.users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userDBcontext.users.ToList();
        }
    }
}
