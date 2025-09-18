using ASPCourceEmpty.Models;
using ASPCourceEmpty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPCourceEmpty.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostcardsRepository _postcardsRepository;

        public HomeController(IPostcardsRepository postcardsRepository)
        {
            _postcardsRepository = postcardsRepository;
        }

        public ViewResult Index()
        {
            var vm = new HomeViewModel(_postcardsRepository.PostcardsOfTheWeek);
            return View(vm);
        }
    }
}