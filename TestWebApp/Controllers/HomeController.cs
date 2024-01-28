using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWebApp.Models;
using TestWebApp.Models.Db;
using TestWebApp.Repository.Interfaces;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogRepository _blogRepository;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _blogRepository = repo;
        }

        public async  Task<IActionResult> Index()
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                JoinDate = DateTime.Now,
            };
            await _blogRepository.AddUser(newUser);
            return View();
        }

        public async Task <IActionResult> Authors()
        {
            var authors = await _blogRepository.GetUsers();

            return View(authors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
