
using Microsoft.AspNetCore.Mvc;



namespace WTechECommerce.UI.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
  
        public IActionResult Index()
        {
            return View();
        }
    }
}
