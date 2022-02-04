using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<OrderDetail> GetListById(int id)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            List<OrderDetail> orderDetails = wTechECommerceContext.OrderDetails.Where(q => q.Id == id && q.IsDeleted == false).ToList();



            return orderDetails;
        }
    }
}
