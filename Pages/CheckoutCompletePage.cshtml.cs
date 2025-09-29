using ASPCourceEmpty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPCourceEmpty.Pages
{
    public class CheckoutCompletePageModel : PageModel
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        public CheckoutCompletePageModel(IShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }

        public void OnGet()
        {
            ViewData["CheckoutCompleteMessage"] = "Thanks for your order";
        }
    }
}