using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WTechECommerce.UI.Areas.Admin.Controllers
{
    public class ErrorController : AdminBaseController
    {
      
        public IActionResult RoleError()
        {
            return View();
        }
    }
}
