using Microsoft.AspNetCore.Mvc;

namespace WTechECommerce.UI.Controllers
{
    public class AdminHomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
