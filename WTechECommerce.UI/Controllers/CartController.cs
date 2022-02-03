using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTechECommerce.Business.Manager.ProductManager;
using WTechECommerce.Data.ORM.Entites;
using WTechECommerce.UI.Models;
using WTechECommerce.UI.Models.Helper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WTechECommerce.UI.Controllers
{
    public class CartController : SiteBaseController
    {

        public IActionResult Index()
        {
            UserCart cart = HttpContext.Session.GetCart("cart");

            List<ProductCartItemVM> model = new List<ProductCartItemVM>();

            if (cart != null)
            {
                decimal totalPrice = 0;
                foreach (var item in cart.UserCartItems)
                {
                    ProductCartItemVM productCartItem = new ProductCartItemVM();

                    Product product = ProductManager.GetProductById(item.ProductId);

                    productCartItem.Title = product.Name;
                    productCartItem.Description = product.Description;
                    productCartItem.UnitPrice = (product.UnitPrice * item.Quantity).ToString();
                    productCartItem.MainImg = product.MainImgPath;
                    productCartItem.Id = product.Id;

                    productCartItem.Quantity = item.Quantity;


                    model.Add(productCartItem);

                    totalPrice = totalPrice + (product.UnitPrice * item.Quantity);

                }

                ViewBag.TotalPrice = totalPrice.ToString("c", CultureInfo.GetCultureInfo("tr-TR"));
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddCart(UserCartItem item)
        {
            //Öncelikle sepet(yani cart) isimli session sistemde var mı ona bakıyoruz. Eğer yoksa yeni bir session create ediyoruz.

            int cartProductCount = 0;
            var cartSession = HttpContext.Session.GetCart("cart");

            if (cartSession == null)
            {
                //Sepete daha önce ürün eklenmemişse yeni bir sepet session oluşturuyorum.

                UserCart userCart = new UserCart();

                List<UserCartItem> userCartItems = new List<UserCartItem>();
                userCartItems.Add(item);

                userCart.UserCartItems = userCartItems;

                HttpContext.Session.SetCart("cart", userCart);
                cartProductCount = 1;

            }
            else
            {
                //Bu ürün daha önce sepete eklendiyse sadece miktarını 1 arttır. Eklenmediyse yeniden ekle


                var cartProductItem = cartSession.UserCartItems.FirstOrDefault(q => q.ProductId == item.ProductId);


                if (cartProductItem == null)
                {
                    cartSession.UserCartItems.Add(item);
                    HttpContext.Session.SetCart("cart", cartSession);

                }
                else
                {
                    cartProductItem.Quantity = cartProductItem.Quantity + 1;
                    HttpContext.Session.SetCart("cart", cartSession);
                }

                cartProductCount = cartSession.UserCartItems.Count();

            }
            

            return Json(cartProductCount);
        }

        public IActionResult RemoveItemFromCart(int id)
        {
            var cartSession = HttpContext.Session.GetCart("cart");

            if (cartSession != null)
            {
                var removeProductItem = cartSession.UserCartItems.FirstOrDefault(q => q.ProductId == id);

                cartSession.UserCartItems.Remove(removeProductItem);


                HttpContext.Session.SetCart("cart", cartSession);

            }

            return RedirectToAction("Index");
        }

        public IActionResult EmptyCart()
        {

            HttpContext.Session.Remove("cart");

            return RedirectToAction("Index");
        }

    }
}
