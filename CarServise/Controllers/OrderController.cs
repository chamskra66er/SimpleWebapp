using CarServise.Data;
using CarServise.Data.Models;
using CarServise.Models.CartViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarServise.Controllers
{
    public class OrderController:Controller
    {
        private readonly IOrder _orderService;
        private Cart _cart;
        public OrderController(IOrder orderService, Cart cart)
        {
            _orderService = orderService;
            _cart = cart;
        }
        public IActionResult List()
        {
            var model = _orderService.Orders;
            return View(model);
        }
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.Lines.Count()==0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                order.ShipStatus = "Ordered";
                order.TotalPrice = _cart.ComputerTotalValue().ToString();

                _orderService.SaveOrder(order);
                _cart.Clear();

                return View("Completed", order);
            }
            else
            {
                return View(order);
            }
        }
        [HttpPost]
        public IActionResult Shipped(int orderId)
        {
            var order = _orderService.GetById(orderId);
            if (order!=null)
            {
                order.ShipStatus = "Shipped";
                _orderService.SaveOrder(order);
            }
            return RedirectToAction("List");
        }
        public IActionResult Completed(Order order)
        {
            _cart.Clear();
            return View(order);
        }
    }
}
