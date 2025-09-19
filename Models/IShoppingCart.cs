namespace ASPCourceEmpty.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Postcard postcard);
        int RemoveFromCart(Postcard postcard);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> Items { get; set; }
    }    
}