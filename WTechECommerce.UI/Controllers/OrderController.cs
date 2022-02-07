using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTechECommerce.Business.Manager.OrderDetailManager;
using WTechECommerce.Business.Manager.OrderManager;
using WTechECommerce.Business.Manager.ProductManager;
using WTechECommerce.Business.Manager.WebUserManager;
using WTechECommerce.Data.ORM.Entites;
using WTechECommerce.UI.Models;
using WTechECommerce.UI.Models.Helper;

namespace WTechECommerce.UI.Controllers
{
    public class OrderController : SiteBaseController
    {
      
        public IActionResult Index()
        {
            UserCart cart = HttpContext.Session.GetCart("cart");
            List<ProductCartItemVM> productCartItemVMs = CartHelper.GetCartProducts(cart);
            ViewBag.TotalPrice = CartHelper.GetTotalPriceWithCurrencyFormat(cart);



            OrderVM orderVM = new OrderVM();
            orderVM.productCartItemVMs = productCartItemVMs;
            orderVM.orderPostVM = new OrderPostVM();



            return View(orderVM);


        }


        [HttpPost]
        public IActionResult CreateOrder(OrderPostVM model)
        {
            if (ModelState.IsValid)
            {
                //Misafir kullanıcı kaydı açtı
                WebUser webUser = new WebUser();
                webUser.IsGuest = true;
                webUser.Name = model.Name;
                webUser.Surname = model.SurName;
                webUser.Email = model.EMail;
                webUser.Phone = model.Phone;

                WebUserManager.Add(webUser);


                //Siparişini genel özelliklerini ekliyoryuz
                Order order = new Order();
                order.WebUserId = webUser.Id;
                order.OrderAddress = model.OrderAddress;
                order.OrderDate = DateTime.Now;

                Random rnd = new Random();
                int orderCode = rnd.Next(1, 100000);

                order.OrderCode = orderCode.ToString();

                OrderManager.Add(order);


                //Sepetten ürünleri çekip sipariş detayı ekliyoruz.

                UserCart cart = HttpContext.Session.GetCart("cart");


                foreach (var item in cart.UserCartItems)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = order.Id;
                    orderDetail.ProductId = item.ProductId;
                    orderDetail.Quantity = item.Quantity;

                    //Fiyat için db den ürünü buluyoruz.

                    Product product = ProductManager.GetProductById(item.ProductId);
                    orderDetail.Price = product.UnitPrice;

                    OrderDetailManager.Add(orderDetail);
                }


            }

            return View("OrderSuccess");
        }

        public IActionResult OrderSuccess()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
}
