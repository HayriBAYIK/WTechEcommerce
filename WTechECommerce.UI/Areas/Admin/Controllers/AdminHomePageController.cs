using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WTechECommerce.UI.Models.Helper;

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
