using ASPCourceEmpty.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCourceEmpty.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class SearchController: ControllerBase
    {
        private readonly IPostcardsRepository _postcardsRepository;

        public SearchController(IPostcardsRepository postcardsRepository)
        {
            _postcardsRepository = postcardsRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var postcards = _postcardsRepository.AllPostcards;
            return Ok(postcards);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_postcardsRepository.AllPostcards.Any(p => p.PostcardId == id))
                return NotFound();

            return Ok(_postcardsRepository.AllPostcards.Where(p => p.PostcardId == id));
        }

        [HttpPost]
        public IActionResult SearchPostcards([FromBody] string searchQuery)
        {
            IEnumerable<Postcard> postcards = new List<Postcard>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                postcards = _postcardsRepository.SearchPostcards(searchQuery);
            }

            return new JsonResult(postcards);
        }
    }
}