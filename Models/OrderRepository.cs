namespace ASPCourceEmpty.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PostcardDBContext _dBContext;
        private readonly IShoppingCart _cart;

        public OrderRepository(PostcardDBContext dBContext, IShoppingCart cart)
        {
            _dBContext = dBContext;
            _cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.PlaceDate = DateTime.UtcNow;
            order.OrderTotal = _cart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();

            foreach (var item in _cart.Items)
            {
                order.OrderDetails.Add(
                    new OrderDetail
                    {
                        Amount = item.Amount,
                        PostcardId = item.Postcard.PostcardId,
                        Price = item.Postcard.Price
                    }
                );
            }

            _dBContext.Orders.Add(order);
            _dBContext.SaveChanges();
        }
    }
}