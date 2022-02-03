﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WTechECommerce.Business.Manager.AdminUserManager;
using WTechECommerce.Data.ORM.Entites;
using WTechECommerce.UI.Models;

namespace WTechECommerce.UI.Controllers
{
    public class AdminUserController : Controller
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