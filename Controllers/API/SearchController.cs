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
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}