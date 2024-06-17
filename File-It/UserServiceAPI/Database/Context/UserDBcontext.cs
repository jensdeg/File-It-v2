using Microsoft.EntityFrameworkCore;
using UserServiceAPI.Models;

namespace UserServiceAPI.Database.Context
{
    public class UserDBcontext : DbContext
    {
        public UserDBcontext(DbContextOptions<UserDBcontext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }

    }
}
