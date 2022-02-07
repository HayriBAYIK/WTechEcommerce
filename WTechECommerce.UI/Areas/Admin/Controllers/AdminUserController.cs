using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WTechECommerce.Business.Manager.AdminUserManager;
using WTechECommerce.Data.ORM.Entites;
using WTechECommerce.UI.Areas.Admin.Controllers;
using WTechECommerce.UI.Models;
using WTechECommerce.UI.Models.Filters;

namespace WTechECommerce.UI.Controllers
{
    [RoleControl("SuperAdmin")]
    public class AdminUserController : AdminBaseController
    {
        public IActionResult Index()
        {
            List<AdminUserVM> adminUsers = AdminUserManager.GetAdminUsers().Select(q => new AdminUserVM()
            {
                Id = q.Id,
                Email = q.Email
            }).ToList();

            return View(adminUsers);
        }

    }
}
