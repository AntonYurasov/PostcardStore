namespace ASPCourceEmpty.Models.ViewModels
{
    public class PostcardListViewModel
    {
        public IEnumerable<Postcard> Postcards { get; }
        public string? CurrentCategory { get; }

        public PostcardListViewModel(IEnumerable<Postcard> postcards, string? currentCategory)
        {
            Postcards = postcards;
            CurrentCategory = currentCategory;
        }
    }
}