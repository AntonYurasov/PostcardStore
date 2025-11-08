using ASPCourceEmpty.Models;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPCourceEmpty.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }


        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            // var order = new Order();
            // _orderRepository.CreateOrder()
            System.Console.WriteLine(order);
            _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.Items.Count == 0)
            {
                ModelState.AddModelError("", "You cart is empty");
            }

            if (ModelState.IsValid)
            {  
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order";
            return View();
        }

    }
}