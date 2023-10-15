using bnm.Data.Migrations;
using bnm.Entities;
using bnm.Models;
using bnm.Views.ViewModel.CART;
using bnm.Views.ViewModel.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace bnm.Controllers
{
    [Authorize(Roles ="Buyer,Seller")]
    public class ORDERController : Controller
    {
        private readonly ApplicationDbContext context;

        public ORDERController(ApplicationDbContext context)
        {
            this.context = context;
        }

        private const string CartCookieName = "ShoppingCart";

        public ActionResult Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Cart> cartItems = GetCartItemsFromCookie(userId);
            return View("Index", cartItems);
        }
        [Authorize(Roles = "Buyer")]
        public IActionResult Chekout()
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ORDER order = new ORDER();
                List<Cart> cartItems = context.carts.Where(c => c.UserAppId == userId && c.oRDERId == null).ToList();
                order.carts = cartItems;
                order.UserAppId = userId;
                order.date= DateTime.Now;
                context.orders.Add(order);
                context.SaveChanges();

                foreach (Cart item in cartItems)
                    {
                    item.oRDERId = order.Id;
                    context.products.Where(p => p.Id == item.ProductId).FirstOrDefault().Quantity -= item.Quantity;
                    context.carts.Update(item);

                  

                    }

                
                        context.SaveChanges();

          
              RemoveCartItemsFromCookie(userId); // Delete cart items from the cookie

                return RedirectToAction("Browse", "Home");
            }
            catch
            {
                // Handle exceptions
                return RedirectToAction("Browse", "Home");
            }
        }

        private List<Cart> GetCartItemsFromCookie(string userId)
        {
            var cookieName = CartCookieName + "_" + userId;
            var cookie = Request.Cookies[cookieName];

            if (cookie != null && !string.IsNullOrEmpty(cookie))
            {
                string cartJson = HttpUtility.UrlDecode(cookie);
                return JsonConvert.DeserializeObject<List<Cart>>(cartJson);
            }

            return new List<Cart>();
        }

        private void RemoveCartItemsFromCookie(string userId)
        {
            var cookieName = CartCookieName + "_" + userId;

            if (Request.Cookies.ContainsKey(cookieName))
            {
                Response.Cookies.Delete(cookieName);
            }
        }
        [Authorize(Roles = "Buyer")]
        public IActionResult GetOrders()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<OrderViewModel> ordersViewModel = new List<OrderViewModel>();
            List<ORDER> orders = context.orders.Where(o => o.UserAppId == userId).ToList();
            foreach (ORDER order in orders)
            {
                OrderViewModel orderViewModel = new OrderViewModel();
                orderViewModel.Id = order.Id;
                orderViewModel.d = order.date;
                List<Cart> cartItems = context.carts.Where(c => c.UserAppId == userId && c.oRDERId == order.Id).ToList();
                decimal totalPrice = 0;
                foreach (Cart item in cartItems)
                {
                    totalPrice += item.Quantity *( context.products.Where(p => p.Id == item.ProductId).FirstOrDefault().Price);
                }
                orderViewModel.totalprice = totalPrice;
                ordersViewModel.Add(orderViewModel);
            }

            return View(ordersViewModel);
        }
        [Authorize(Roles = "Buyer")]

        public IActionResult Details(int id)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                List<CC> carts = new List<CC>();
                List<Cart> cartItems = context.carts.Where(c => c.UserAppId == userId && c.oRDERId == id).ToList();
                decimal totalPrice = 0;
                foreach (Cart item in cartItems)
                {
                    CC cartItem = new CC();
                cartItem.productId = context.products.Where(p => p.Id == item.ProductId).FirstOrDefault().Id;
                    cartItem.productname = context.products.Where(p => p.Id == item.ProductId).FirstOrDefault().Name;
                    cartItem.p = context.products.Where(p => p.Id == item.ProductId).FirstOrDefault().Price;
                    cartItem.q = item.Quantity;
                cartItem.pq = cartItem.q * cartItem.p;
                cartItem.pic=context.products.Where(p => p.Id == item.ProductId).FirstOrDefault().ImageUrl;





                carts.Add(cartItem);


                }
                return View(carts);


            }


        }
    }

    
