using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Repository.Interfaces;

namespace TestWebApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogRepository _logRepo;
        public LogsController(ILogRepository repo)
        {
            _logRepo = repo;
        }
        public async Task<ActionResult> Index()
        {
            var logs = await _logRepo.GetLogs();
            return View(logs);
        }
    }
}
