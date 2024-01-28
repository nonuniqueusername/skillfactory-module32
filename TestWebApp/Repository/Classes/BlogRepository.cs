using Microsoft.EntityFrameworkCore;
using TestWebApp.DbConnect;
using TestWebApp.Models.Db;
using TestWebApp.Repository.Interfaces;

namespace TestWebApp.Repository.Classes
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task AddUser(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            var entry = _context.Entry(user);
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                await _context.Users.AddAsync(user);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }
    }
}
