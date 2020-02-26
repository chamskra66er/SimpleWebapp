using CarServise.Data;
using CarServise.Data.Models;
using CarServise.Models.CartViewModels;
using CarServise.Models.ForumViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarServise.Controllers
{
    public class CartController:Controller
    {
        private IForum _forumService;
        public Cart cart;

        public CartController(IForum forumService, Cart cart)
        {
            this.cart = cart;
            _forumService = forumService;
        }
        //public ViewResult Index(Cart _cart)
        //{
        //    var model = new CartIndexModel
        //    {
        //        Cart = _cart
        //    };
        //    return View(model);
        //}
        public IActionResult AddToCart(int id)
        {
            var forum = _forumService.GetById(id);
            if (forum!=null)
            {
                cart.AddItem(forum, 1);              
            }
            var model = new CartIndexModel
            {
                Cart = cart
            };
            return View("Index", model);
        }
        public RedirectToActionResult RemoveFromCart(int forumId,
                string returnUrl)
        {
            var forum = _forumService.GetById(forumId);

            if (forum != null)
            {
                cart.RemoveLine(forum);
            }
            return RedirectToAction("Index","Cart", new { returnUrl });
        }


    }
}
