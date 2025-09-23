
using Microsoft.EntityFrameworkCore;

namespace ASPCourceEmpty.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly PostcardDBContext _postcardDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = default!;
        private ShoppingCart(PostcardDBContext postcardDbContext)
        {
            _postcardDbContext = postcardDbContext;
        }

        public void AddToCart(Postcard postcard)
        {
            var shoppingCartItem =
                    _postcardDbContext.CartItems.SingleOrDefault(
                        s => s.Postcard.PostcardId == postcard.PostcardId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Postcard = postcard,
                    Amount = 1
                };

                _postcardDbContext.CartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _postcardDbContext.SaveChanges();
        }

        public int RemoveFromCart(Postcard postcard)
        {
            var shoppingCartItem =
                    _postcardDbContext.CartItems.SingleOrDefault(
                        s => s.Postcard.PostcardId == postcard.PostcardId && s.ShoppingCartId == ShoppingCartId);

            int localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _postcardDbContext.CartItems.Remove(shoppingCartItem);
                }
            }

            _postcardDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return Items ??=
                       _postcardDbContext.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Postcard)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _postcardDbContext
                .CartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _postcardDbContext.CartItems.RemoveRange(cartItems);

            _postcardDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _postcardDbContext.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Postcard.Price * c.Amount).Sum();
            return total;
        }


        //static get cart
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            PostcardDBContext context = services.GetService<PostcardDBContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
    }
}