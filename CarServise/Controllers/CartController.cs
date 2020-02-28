using CarServise.Data;
using CarServise.Models.CartViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarServise.Controllers
{
    public class CartController : Controller
    {
        private IForum _forumService;
        private Cart _cart;

        public CartController(IForum forumService, Cart cart)
        {
            _cart = cart;
            _forumService = forumService;
        }
        public IActionResult Index()
        {
            var model = new CartIndexModel
            {
                Cart = _cart
            };
            return View(model);
        }
        public IActionResult AddToCart(int id)
        {
            var forum = _forumService.GetById(id);
            if (forum!=null)
            {
                _cart.AddItem(forum, 1);
            }
            
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromCart(int forumId,
                string returnUrl)
        {
            var forum = _forumService.GetById(forumId);

            if (forum != null)
            {
                _cart.RemoveLine(forum);
            }
            return RedirectToAction("Index","Cart", new { returnUrl });
        }       
    }
}
