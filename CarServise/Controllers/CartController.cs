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
        private Cart _cart;

        public CartController(Cart cart,
            IForum forumService)
        {
            _cart = cart;
            _forumService = forumService;
        }
        public IActionResult Index()
        {
            var model = new CartIndexModel
            {
                Cart = _cart
                //ReturnUrl = returnUrl
            };
            return View(model);
        }
        //[HttpPost]
        public IActionResult AddToCart(int id)
        {
            //var modelId = model.Id;
            var forum = _forumService.GetById(id);
            if (forum!=null)
            {
                _cart.AddItem(forum, 1);              
            }
            return RedirectToAction("Index"); /*new { returnUrl }*/
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
