namespace ASPCourceEmpty.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PostcardId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Postcard Card { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}