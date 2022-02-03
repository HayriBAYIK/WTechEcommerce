using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WTechECommerce.Data.ORM.Context;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.Business.Manager.AdminUserManager
{
    public class AdminUserManager
    {

        
        public static List<AdminUser> GetAdminUsers()
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            List<AdminUser> adminUsers = wTechECommerceContext.AdminUsers.Where(q => q.IsDeleted == false).ToList();

            return adminUsers;

        }
    

        public static AdminUser GetAdminUserById(int id)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            AdminUser adminUser = wTechECommerceContext.AdminUsers.FirstOrDefault(q => q.Id == id && q.IsDeleted == false);

            return adminUser;

        }

        public static void Add(AdminUser adminUser)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();


            adminUser.IsDeleted = false;
            adminUser.AddDate = DateTime.Now;

            wTechECommerceContext.AdminUsers.Add(adminUser);
            wTechECommerceContext.SaveChanges();
        }

        public static void Update(AdminUser adminUser)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            int id = adminUser.Id;

            AdminUser theAdminUser = GetAdminUserById(id);

            theAdminUser.Email = adminUser.Email;
            theAdminUser.Password = adminUser.Password;

            wTechECommerceContext.SaveChanges();

        }


        public static void Delete(int id)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            AdminUser adminUser = GetAdminUserById(id);

            adminUser.IsDeleted = true;

            wTechECommerceContext.SaveChanges();
            
        }


    }
}
