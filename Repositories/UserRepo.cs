using DiazFrontDeskApp.Data;
using DiazFrontDeskApp.Interfaces;
using DiazFrontDeskApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiazFrontDeskApp.Repositories
{

    public class UserRepo : IUser
    {

        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Edit(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public User GetItem(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public IEnumerable<User> GetItems()
        {
            return _context.Users.ToList();
        }
    }
}
