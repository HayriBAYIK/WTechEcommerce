using System;
using WTechECommerce.Data.ORM.Context;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.Business.Manager.OrderManager
{
    public class OrderManager
    {
        public static void Add(Order order)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            order.IsDeleted = false;
            order.AddDate = DateTime.Now;

            wTechECommerceContext.Orders.Add(order);
            wTechECommerceContext.SaveChanges();
        }
    }
}
