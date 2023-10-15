using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using bnm.Models;
using Humanizer;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Web;
using System.Xml.Linq;
using System;
using bnm.Entities;
using bnm.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static NuGet.Packaging.PackagingConstants;
using System.Runtime.ConstrainedExecution;

namespace bnm.Controllers
{
    [Authorize(Roles="Buyer")]
 
    public class CartController : Controller
    {
        private readonly ApplicationDbContext context;

        public CartController(ApplicationDbContext context)
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
        public ActionResult AddToCart(int productId, string productName, int quantity, int price)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Cart> cartItems = GetCartItemsFromCookie(userId);

            Cart existingItem = cartItems.FirstOrDefault(item => item.ProductId == productId&&userId==item.UserAppId);

            if (existingItem != null)
            {
                Product p = context.products.Find(productId);

                if (existingItem.Quantity >= p.Quantity)
                {
                    existingItem.Quantity = p.Quantity;
                    existingItem.Price = p.Price;
                }
                else
                {
                    // Update quantity if the product already exists in the cart
                    existingItem.Quantity += quantity;
                    context.Update(existingItem);
                    context.SaveChanges();
                }
            }
            else
            {
                // Add new item to the cart
                Cart newItem = new Cart
                {
                    ProductId = productId,
                    ProductName = productName,
                    Quantity = 1,
                    Price = price,
                    UserAppId = userId,
                  
                };

                context.carts.Add(newItem);
                context.SaveChanges();

                cartItems.Add(newItem);
            }
            context.products.Where(s => s.Id == productId).FirstOrDefault().Quantity -= 1;
            context.SaveChanges();

            SaveCartItemsToCookie(cartItems, userId);

            return RedirectToAction("Index");
        }

        public ActionResult UpdateCart(int productId, int quantity)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Cart> cartItems = GetCartItemsFromCookie(userId);

            Cart existingItem = cartItems.FirstOrDefault(item => item.ProductId == productId && userId == item.UserAppId);

            if (existingItem != null)
            {
                // Update quantity if the product already exists in the cart
                existingItem.Quantity += quantity;
                context.carts.Update(existingItem);
                context.SaveChanges();

                if (existingItem.Quantity <= 0)
                {
                    cartItems.Remove(existingItem);
                }
                else
                {
                    Product p = context.products.Find(productId);

                    if (existingItem.Quantity > p.Quantity)
                    {
                        existingItem.Quantity = p.Quantity;
                        context.SaveChanges();

                    }
                }
                

                SaveCartItemsToCookie(cartItems, userId);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Cart> cartItems = GetCartItemsFromCookie(userId);

            Cart item = cartItems.FirstOrDefault(item => item.ProductId == productId);
            if (item != null)
            {
                cartItems.Remove(item);
                SaveCartItemsToCookie(cartItems, userId);
            }

            return RedirectToAction("Index");
        }

        public List<Cart> GetCartItemsFromCookie(string userId)
        {
            var cookie = Request.Cookies[CartCookieName + "_" + userId];
            if (cookie != null && !string.IsNullOrEmpty(cookie))
            {
                string cartJson = HttpUtility.UrlDecode(cookie);
                return JsonConvert.DeserializeObject<List<Cart>>(cartJson);
            }

            return new List<Cart>();
        }

        private void SaveCartItemsToCookie(List<Cart> cartItems, string userId)
        {
            var cartJson = JsonConvert.SerializeObject(cartItems);
            Response.Cookies.Append(CartCookieName + "_" + userId, cartJson);
        }
    }
}