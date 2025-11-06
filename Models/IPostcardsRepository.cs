namespace ASPCourceEmpty.Models
{
    public interface IPostcardsRepository
    {
        IEnumerable<Postcard> AllPostcards { get; }
        IEnumerable<Postcard> PostcardsOfTheWeek { get; }
        Postcard? GetPostcardById(int postcardId);

        IEnumerable<Postcard> SearchPostcards(string searchQuery);
    }
}