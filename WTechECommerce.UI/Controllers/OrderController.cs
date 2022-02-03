using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                WebUser webUser = new WebUser();
                webUser.IsGuest = true;
                webUser.Name = model.Name;
                webUser.Surname = model.SurName;
                webUser.Email = model.EMail;
                webUser.Phone = model.Phone;

                WebUser newWebUser = WebUserManager.Add(webUser);



                Order order = new Order();
                order.WebUserId = newWebUser.Id;
                order.OrderAddress = model.OrderAddress;
                order.OrderDate = DateTime.Now;
               

                
            }

            return View();
        }
    }
}
