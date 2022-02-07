using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WTechECommerce.Business.Manager.AdminUserManager;
using WTechECommerce.Data.ORM.Entites;
using WTechECommerce.UI.Models;

namespace WTechECommerce.UI.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminLoginVM model)
        {
            AdminUser adminUser = AdminUserManager.AdminUserLoginControl(model.EMail, model.Password);

            if (adminUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, adminUser.Email),
                    new Claim(ClaimTypes.Name, adminUser.Id.ToString()),
                    new Claim(ClaimTypes.Role, adminUser.Role)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                return RedirectToAction("Index", "AdminLogin");

            }


        }


        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}
