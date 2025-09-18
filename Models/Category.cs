namespace ASPCourceEmpty.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Postcard>? Postcards { get; set; }
    }
}
