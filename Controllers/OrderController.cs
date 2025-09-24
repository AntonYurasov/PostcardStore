using ASPCourceEmpty.Models;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;

namespace ASPCourceEmpty.Controllers
{
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
        public void Post(Order order)
        {
            // var order = new Order();
            // _orderRepository.CreateOrder()
            System.Console.WriteLine(order);
        }

        public IActionResult Checkout()
        {
            return View();
        }

    }
}