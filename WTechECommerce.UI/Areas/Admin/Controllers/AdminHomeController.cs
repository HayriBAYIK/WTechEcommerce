
using Microsoft.AspNetCore.Mvc;
using WTechECommerce.UI.Models.Filters;

namespace WTechECommerce.UI.Areas.Admin.Controllers
{
    [RoleControl("Editor")]
    public class AdminHomeController : AdminBaseController
    {
  
        public IActionResult Index()
        {
            return View();
        }
    }
}
