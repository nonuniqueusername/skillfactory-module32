using TestWebApp.Models.Db;

namespace TestWebApp.Repository.Interfaces
{
    public interface ILogRepository
    {
        Task Log(string url);
        Task<Request[]> GetLogs();
    }
}
