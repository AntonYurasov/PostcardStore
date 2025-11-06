using Microsoft.EntityFrameworkCore;

namespace ASPCourceEmpty.Models
{
    public class PostcardRepository : IPostcardsRepository
    {

        private readonly PostcardDBContext _postcardDBContext;

        public PostcardRepository(PostcardDBContext postcardDBContext)
        {
            _postcardDBContext = postcardDBContext;
        }

        public IEnumerable<Postcard> AllPostcards => _postcardDBContext.Postcards.Include(p => p.Category);

        public IEnumerable<Postcard> PostcardsOfTheWeek => _postcardDBContext.Postcards.Include(p => p.Category).Where(x => x.IsPostcardOfTheWeek);

        public Postcard? GetPostcardById(int postcardId) =>
            _postcardDBContext.Postcards.FirstOrDefault(p => p.PostcardId == postcardId);

        public IEnumerable<Postcard> SearchPostcards(string searchQuery)
        {
            return _postcardDBContext.Postcards.Where(p => p.Name.Contains(searchQuery));
        }
    }
}