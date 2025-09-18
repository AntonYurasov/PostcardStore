using ASPCourceEmpty.Models;
using ASPCourceEmpty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPCourceEmpty.Controllers
{
    public class PostcardController : Controller
    {
        private readonly IPostcardsRepository _postcardsRepository;

        public PostcardController(IPostcardsRepository postcardsRepository)
        {
            _postcardsRepository = postcardsRepository;
        }

        public ViewResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            // ViewBag.CurrentCategory = "Seasons";
            ViewBag.Title = "Postcards";
            return View(new PostcardViewModel(_postcardsRepository.AllPostcards, "Seasons"));
        }

        public IActionResult Details(int id)
        {
            var postcard = _postcardsRepository.GetPostcardById(id);
            if (postcard == null)
                return NotFound();

            return View(postcard);
        }
    }
}