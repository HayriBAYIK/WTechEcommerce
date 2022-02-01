using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WTechECommerce.UI.Models.Helper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WTechECommerce.UI.Controllers
{
    public class SiteBaseController : Controller
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cartSession = HttpContext.Session.GetCart("cart");
            if (cartSession != null)
            {
                ViewBag.cartItemCount = cartSession.UserCartItems.Count();

            }
            else
            {
                ViewBag.cartItemCount = 0;
            }
        }
    }
}
