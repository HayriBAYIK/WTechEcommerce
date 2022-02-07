using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            var CurrentUserEmail = User.Claims.FirstOrDefault(q => q.Type == ClaimTypes.Email).Value.ToString();

            List<AdminUserVM> adminUsers = AdminUserManager.GetAdminUsers(CurrentUserEmail).Select(q => new AdminUserVM()
            {
                Id = q.Id,
                Email = q.Email,
                Password=q.Password,
                Role = q.Role,
                

            }).ToList();

            return View(adminUsers);

        }

        public IActionResult Add()
        {
            AdminUserAddVM model = new AdminUserAddVM();

            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AdminUserAddVM adminUserAddVM)
        {
            if (ModelState.IsValid)
            {
                AdminUser adminUser = new AdminUser();
                adminUser.Email = adminUserAddVM.EMail;
                adminUser.Password = adminUserAddVM.Password;
                adminUser.Role = adminUserAddVM.drpRoles;

                AdminUserManager.Add(adminUser);
                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Update(int id)
        {
            AdminUserUpdateVM adminUserUpdateVM = new AdminUserUpdateVM();
            AdminUser adminUser = AdminUserManager.GetAdminUserById(id);

            adminUserUpdateVM.EMail = adminUser.Email;
            adminUserUpdateVM.drpRoles = adminUser.Role;
            adminUserUpdateVM.Id = adminUser.Id;

            return View(adminUserUpdateVM);


        }
        [HttpPost]
        public IActionResult Update(AdminUserUpdateVM adminUserUpdateVM)
        {


            AdminUser adminUser = new AdminUser();
            adminUser.Id = adminUserUpdateVM.Id;
            adminUser.Email = adminUserUpdateVM.EMail;
            adminUser.Role = adminUserUpdateVM.drpRoles;

            AdminUserManager.Update(adminUser);

            return RedirectToAction("Index", "AdminUser");


        }
        public IActionResult Delete(int id)
        {

            return RedirectToAction("Index", "AdminUser");
        }
    }
}
