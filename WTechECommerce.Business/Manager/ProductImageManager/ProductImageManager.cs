using System;
using System.Collections.Generic;
using System.Linq;
using WTechECommerce.Data.ORM.Context;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.Business.Manager.ProductImageManager
{
    public class ProductImageManager
    {

        public static void Add(ProductImage productImage)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();
            wTechECommerceContext.ProductImages.Add(productImage);
            wTechECommerceContext.SaveChanges();

        }


        public static List<ProductImage> GetProductImagesByProductId(int id)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();


            List<ProductImage> productImages = wTechECommerceContext.ProductImages.Where(q => q.ProductId == id && q.IsDeleted == false).ToList();


            return productImages;
        }

    }
}
