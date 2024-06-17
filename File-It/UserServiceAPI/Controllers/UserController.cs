using Microsoft.AspNetCore.Mvc;
using UserServiceAPI.Interfaces;
using UserServiceAPI.Repos;
using UserServiceAPI.Models;

namespace UserServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly iUserRepo _userRepo;
        public UserController(iUserRepo userrepo)
        {
            _userRepo = userrepo;
        }

        [HttpGet("All")]
        public IEnumerable<User> GetUsers()
        {
            return _userRepo.GetUsers();
        }

        [HttpGet("Get/{id}")]
        public User? GetUserById(Guid id)
        {
            return _userRepo.GetUserById(id);
        }

        [HttpPost("Create")]
        public void CreateUser(User user)
        {
            _userRepo.CreateUser(user);
        }

        [HttpPut("Update")]
        public void UpdateUser(User user)
        {
            _userRepo.UpdateUser(user);
        }

        [HttpDelete("Delete")]
        public void DeleteUser(User user)
        {
            _userRepo.DeletUser(user);
        }
    }
}
