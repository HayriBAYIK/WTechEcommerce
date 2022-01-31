using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTechECommerce.Business.Manager.CategoryManager;
using WTechECommerce.Business.Manager.ProductManager;
using WTechECommerce.Data.ORM.Entites;
using WTechECommerce.UI.Areas.Admin.Models;

namespace WTechECommerce.UI.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
 
        public IActionResult Index()
        {
            return View();
        }


 
        public IActionResult Add()
        {
            AdminProductVM model = new AdminProductVM();
            model.drpCategories = getDrpCategories();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AdminProductVM model)
        {
            Product product = new Product();
            product.Name = model.Name;
            product.Description = model.Description;
            product.CategoryId = model.CategoryId;
            product.Code = model.Code;

            string mainProductPath = "";

            //Öncelikle uniq dosya adı oluşturmak için Guid kullanıyoruz
            var guid = Guid.NewGuid().ToString();

            //Yüklenecek olan dosyanın uzantısını alıyorum
            var extension = Path.GetExtension(model.MainProductImg.FileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/site/products", guid + extension);

            using (var stream = System.IO.File.Create(path))
            {
                model.MainProductImg.CopyTo(stream);
            }


            mainProductPath = guid + extension;

            product.MainImgPath = mainProductPath;


            ProductManager.Add(product);


            return View();
        }

        private List<CategoryVM> getDrpCategories()
        {
            List<CategoryVM> categories = CategoryManager.GetCategories().Select(q => new CategoryVM()
            {
                Name = q.Name,
                Id = q.Id
            }
           ).ToList();

            return categories;
        }



    }
}
