namespace ASPCourceEmpty.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Pies", Description="Tasty pies for eveeryone"},
                new Category{CategoryId=2, CategoryName="Animals", Description="Different animals"},
                new Category{CategoryId=3, CategoryName="Vehicles", Description="Vehicle"}
            };
    }
}
