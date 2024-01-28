using TestWebApp.Models.Db;

namespace TestWebApp.Repository.Interfaces
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
