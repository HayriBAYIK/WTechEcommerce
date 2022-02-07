using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WTechECommerce.Data.ORM.Context;
using WTechECommerce.Data.ORM.Entites;
using Microsoft.EntityFrameworkCore;

namespace WTechECommerce.Business.Manager.OrderListManager
{
    public class OrderListManager
    {
        public static List<Order> GetAllOrder( )
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            List<Order> orders = wTechECommerceContext.Orders.Include(q=>q.WebUser).Where(q=>q.IsDeleted==false).ToList();

            return orders;
        }
        public static List<OrderDetail> GetOrderDetailById(int id)
        {

            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            List<OrderDetail> orderDetails = wTechECommerceContext.OrderDetails.Include(q=>q.Product).Where(q => q.OrderId == id && q.IsDeleted == false).ToList();

            return orderDetails;
        }

        public static decimal OrderTotalPrice(int id)
        {
            WTechECommerceContext wTechECommerceContext = new WTechECommerceContext();

            decimal totalPrice = wTechECommerceContext.OrderDetails.Where(q => q.OrderId == id).Select(i => i.Price * i.Quantity).Sum();

            return totalPrice;

        }

    }
}
