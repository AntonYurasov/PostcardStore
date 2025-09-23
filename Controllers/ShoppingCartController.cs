using ASPCourceEmpty.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPCourceEmpty.Models
{
    public class ShoppingCartController : Controller
    {
        private readonly IPostcardsRepository _postcardsRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IPostcardsRepository postcardsRepository, IShoppingCart shoppingCart)
        {
            _postcardsRepository = postcardsRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            _shoppingCart.GetShoppingCartItems();
            // _shoppingCart.Items = items;

            var shoppingCartVm = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartVm);
        }

        public RedirectToActionResult AddToShoppingCart(int postcardId)
        {
            var postcard = _postcardsRepository.AllPostcards.FirstOrDefault(x => x.PostcardId == postcardId);

            if (postcard != null)
            {
                _shoppingCart.AddToCart(postcard);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int postcardId)
        {
            var postcard = _postcardsRepository.AllPostcards.FirstOrDefault(x => x.PostcardId == postcardId);

            if (postcard != null)
            {
                _shoppingCart.RemoveFromCart(postcard);
            }

            return RedirectToAction("Index");
        }
    }
}