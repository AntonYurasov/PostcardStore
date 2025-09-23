using ASPCourceEmpty.Models;
using ASPCourceEmpty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPCourceEmpty.Controllers
{
    public class PostcardController : Controller
    {
        private readonly IPostcardsRepository _postcardsRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PostcardController(IPostcardsRepository postcardsRepository, ICategoryRepository categoryRepository)
        {
            _postcardsRepository = postcardsRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            return View();
        }

        public IActionResult List(string category)
        {
            ViewBag.Title = "Postcards";
            var foundCategory = _categoryRepository.AllCategories.FirstOrDefault(x => x.CategoryName == category);

            string categoryName = "Seasons";
            IEnumerable<Postcard> postcards = _postcardsRepository.AllPostcards;

            if (foundCategory != null)
            {
                categoryName = foundCategory.CategoryName;
                postcards = _postcardsRepository.AllPostcards.Where(x => x.Category.CategoryName == foundCategory.CategoryName).OrderBy(x=>x.PostcardId);
            }


            return View(new PostcardListViewModel(postcards, categoryName));
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