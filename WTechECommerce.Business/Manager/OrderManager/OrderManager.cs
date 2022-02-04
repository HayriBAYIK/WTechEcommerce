using System;
using System.Linq;
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

        public static Order GetOrderById(int id)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            Order order = wTechECommerceContext.Orders.FirstOrDefault(q=>q.Id==id&&q.IsDeleted==false);

            return order;
        }
    }
}
