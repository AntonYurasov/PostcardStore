namespace ASPCourceEmpty.Models.ViewModels
{
    public class PostcardViewModel
    {
        public IEnumerable<Postcard> Postcards { get; }
        public string? CurrentCategory { get; }

        public PostcardViewModel(IEnumerable<Postcard> postcards, string? currentCategory)
        {
            Postcards = postcards;
            CurrentCategory = currentCategory;
        }
    }
}