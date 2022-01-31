using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WTechECommerce.Data.ORM.Context;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.Business.Manager.ProductManager
{
    public class ProductManager
    {
        //List
        public static List<Product> GetProducts()
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();
            List<Product> products = wTechECommerceContext.Products.Where(x => x.IsDeleted == false).ToList();
            return products;
        }
        //Add
        public static void Add(Product product)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();
            product.IsDeleted = false;
            product.AddDate = DateTime.Now;
            wTechECommerceContext.Products.Add(product);
            wTechECommerceContext.SaveChanges();
        }
        public static void Delete(int id)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();
            Product product = wTechECommerceContext.Products.FirstOrDefault(x => x.Id == id);
            product.IsDeleted = true;
            wTechECommerceContext.SaveChanges();
        }
    }
}
