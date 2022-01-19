using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTechECommerce.Business.Manager.CategoryManager;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.UI.Controllers
{
    public class CategoryController : Controller
    {
    
        public IActionResult Index()
        {
            List<Category> categories = CategoryManager.GetCategories();


            return View(categories);
        }


        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Category category)
        {
            CategoryManager.Add(category);

            return View();
        }

        public IActionResult Detail(int id)
        {
            Category category = CategoryManager.GetCategory(id);

            return View(category);

        }
    }
}
