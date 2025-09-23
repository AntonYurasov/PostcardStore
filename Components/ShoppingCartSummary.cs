using ASPCourceEmpty.Models;
using ASPCourceEmpty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPCourceEmpty.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            _shoppingCart.GetShoppingCartItems();

            var vm = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(vm);
        }
    }
}