using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WTechECommerce.UI.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //var adminUserEMail = User.Claims.ToArray()[0].Value;

            var userClaim = User.Claims.FirstOrDefault(q => q.Type == ClaimTypes.Email);

            if (userClaim != null)
            {
                ViewBag.AdminEmail = userClaim.Value;
            }


        }
    }
}
