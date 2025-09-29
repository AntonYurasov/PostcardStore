using ASPCourceEmpty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPCourceEmpty.Pages
{
    public class CheckoutPageModel : PageModel
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        [BindProperty]
        public Order Order { get; set; }

        public CheckoutPageModel(IShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty!");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(Order);
                _shoppingCart.ClearCart();
                return RedirectToPage("CheckoutCompletePage");
            }

            return Page();
        }
    }
}