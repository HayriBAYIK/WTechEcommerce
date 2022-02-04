using System;
using WTechECommerce.Data.ORM.Context;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.Business.Manager.OrderDetailManager
{
    public class OrderDetailManager
    {
        public static void Add(OrderDetail orderDetail)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            orderDetail.IsDeleted = false;
            orderDetail.AddDate = DateTime.Now;

            wTechECommerceContext.OrderDetails.Add(orderDetail);
            wTechECommerceContext.SaveChanges();
        }
    }
}
