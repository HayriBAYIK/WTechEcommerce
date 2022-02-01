using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTechECommerce.Business.Manager.CategoryManager;
using WTechECommerce.Data.ORM.Entites;
using WTechECommerce.UI.Models;

namespace WTechECommerce.UI.Controllers
{
    public class CategoryController : Controller
    {
    
        public IActionResult Index()
        {
            List<CategoryVM> categories = CategoryManager.GetCategories().Select(q => new CategoryVM()
            {
                Id = q.Id,
                Name = q.Name,
                AddDate = q.AddDate,
                IsDeleted = q.IsDeleted

            }).ToList();         


            return View(categories);
        }


        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(CategoryVM categoryVm)
        {
            Category category = new Category();
            category.Name = categoryVm.Name; 
            CategoryManager.Add(category);


            return View();
        }

        public IActionResult Detail(int id)
        {

            Category category = CategoryManager.GetCategoryById(id);

            if (category != null)
            {
                CategoryVM model = new CategoryVM();
                model.Id = category.Id;
                model.Name = category.Name;
                model.AddDate = category.AddDate;
                model.IsDeleted = category.IsDeleted;               

                return View(model);
            }

            return RedirectToAction("Index","Category");
        }

        public IActionResult AddCategory(CategoryVM categoryVm)
        {
            Category category = new Category();
            category.Name = categoryVm.Name;
            CategoryManager.Add(category);


            categoryVm.AddDate = category.AddDate;
            categoryVm.Id = category.Id;

            return Json(categoryVm);

        }
       
    }
}
