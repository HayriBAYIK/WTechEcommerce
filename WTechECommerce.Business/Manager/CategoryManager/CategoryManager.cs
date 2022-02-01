using System;
using System.Collections.Generic;
using System.Linq;
using WTechECommerce.Data.ORM.Context;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.Business.Manager.CategoryManager
{
    public class CategoryManager
    {
        //list
        public static List<Category> GetCategories()
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            List<Category> categories = wTechECommerceContext.Categories.Where(q => q.IsDeleted == false).ToList();

            return categories;

        }

        //getByid
        public static Category GetCategoryById(int id)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            Category category = wTechECommerceContext.Categories.FirstOrDefault(q => q.Id == id && q.IsDeleted == false);

            return category;
        }

        public static void Add(Category category)
        {
        
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            category.IsDeleted = false;
            category.AddDate = DateTime.Now;

            wTechECommerceContext.Categories.Add(category);
            wTechECommerceContext.SaveChanges();


        }

        public static void Delete(int id)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            Category category = wTechECommerceContext.Categories.FirstOrDefault(q => q.Id == id);
            category.IsDeleted = true;

            wTechECommerceContext.SaveChanges();

        }

    }
}
