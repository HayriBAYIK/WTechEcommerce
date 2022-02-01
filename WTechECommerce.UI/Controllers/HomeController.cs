using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using WTechECommerce.Business.Manager.ProductImageManager;
using WTechECommerce.Business.Manager.ProductManager;
using WTechECommerce.Data.ORM.Entites;
using WTechECommerce.UI.Models;
using WTechECommerce.UI.Models.Helper;

namespace WTechECommerce.UI.Controllers
{
    public class HomeController : SiteBaseController
    {

        [Route("Anasayfa")]
        [Route("")]
        public IActionResult Index()
        {
            List<ProductVM> model = ProductManager.GetProducts().Take(10).Select(q => new ProductVM()
            {
                Id = q.Id,
                Description=q.Description,
                Name = q.Name,
                UnitPrice = q.UnitPrice.ToString(),
                MainImgPath = q.MainImgPath,
                urlSlug = PageUrlHelper.FriendlyUrl(q.Name)

        }).ToList();

           

            return View(model);
        }


        [Route("{id}/{name}")]
        public IActionResult Detail(int id, string name)
        {
            Product product = ProductManager.GetProductById(id);

            if(product != null)
            {
                ProductVM model = new ProductVM();
                model.Id = product.Id;
                model.Name = product.Name;
                model.UnitPrice = product.UnitPrice.ToString();
                model.urlSlug = PageUrlHelper.FriendlyUrl(product.Name);



                List<ProductImage> productImages = ProductImageManager.GetProductImagesByProductId(id);

                model.ImagePaths = productImages.Select(q => q.ImagePath).ToList();

                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
