namespace ASPCourceEmpty.Models.ViewModels
{
    public class HomeViewModel
    {
        public readonly IEnumerable<Postcard> postcardsOfTheWeek;

        public HomeViewModel(IEnumerable<Postcard> postcardsOfTheWeek)
        {
            this.postcardsOfTheWeek = postcardsOfTheWeek;
        }
    }
}