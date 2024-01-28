using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Models.Db;
using TestWebApp.Repository.Interfaces;

namespace TestWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public UsersController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        // GET: UsersController
        public async Task <ActionResult> Index()
        {
            var authors = await _blogRepository.GetUsers();

            return View(authors);
        }

        public async Task<ActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(User newUser)
        {

            _blogRepository.AddUser(newUser);
            return View(newUser);
        }



    }
}
