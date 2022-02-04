using System;
using WTechECommerce.Data.ORM.Context;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.Business.Manager.WebUserManager
{
    public class WebUserManager
    {

        public static WebUser Add(WebUser webUser)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            webUser.AddDate = DateTime.Now;
            webUser.IsDeleted = false;
            wTechECommerceContext.Add(webUser);
            wTechECommerceContext.SaveChanges();

            return webUser;

        }
    }
}
