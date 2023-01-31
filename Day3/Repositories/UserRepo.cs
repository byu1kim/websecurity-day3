using Day3.Data;
using Day3.Models;
using Day3.ViewModels;

namespace Day3.Repositories
{
    public class UserRepo
    {
        ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserVM> All()
        {
            IEnumerable<UserVM> users = _context.Users.Select(u => new UserVM() { Email = u.Email });
            return users; // you don’t have to specify ‘AspNetUsers’.. just ‘Users’
        }

        public MyRegisteredUser GetUser(string email)
        {
            return _context.MyRegisteredUsers.Where(item => item.Email == email).FirstOrDefault(); ;
        }

    }
}
