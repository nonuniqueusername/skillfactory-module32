using Microsoft.EntityFrameworkCore;
using TestWebApp.DbConnect;
using TestWebApp.Models.Db;
using TestWebApp.Repository.Interfaces;

namespace TestWebApp.Repository.Classes
{
    public class LogRepository : ILogRepository
    {
        private readonly BlogContext _context;

        public LogRepository(BlogContext blogContext)
        {
            _context = blogContext;
        }

        public async Task<Request[]> GetLogs()
        {
            return await _context.Requests.OrderByDescending(item => item.Date).ToArrayAsync();
        }

        public async Task Log(string url)
        {
            var request = new Request()
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Url = url
            };
            var entry = _context.Entry(request);
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                await _context.Requests.AddAsync(request);
            }
            await _context.SaveChangesAsync();
        }
    }
}
