
namespace ASPCourceEmpty.Models
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly PostcardDBContext _postcardDBContext;

        public CategoryRepository(PostcardDBContext postcardDBContext)
        {
            _postcardDBContext = postcardDBContext;
        }

        public IEnumerable<Category> AllCategories => _postcardDBContext.Categories.OrderBy(x => x.CategoryName);
    }
} 