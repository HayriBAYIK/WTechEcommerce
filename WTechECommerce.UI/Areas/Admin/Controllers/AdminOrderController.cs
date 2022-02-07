using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTechECommerce.Business.Manager.OrderListManager;
using WTechECommerce.Business.Manager.OrderManager;
using WTechECommerce.Business.Manager.ProductManager;
using WTechECommerce.Business.Manager.WebUserManager;
using WTechECommerce.UI.Areas.Admin.Controllers;
using WTechECommerce.UI.Models;
using WTechECommerce.UI.Models.Filters;

namespace WTechECommerce.UI.Controllers
{
    [RoleControl("SuperAdmin")]
    public class AdminOrderController : AdminBaseController
    {
        public IActionResult Index()
        {


            List<OrderListVM> OrderList = OrderListManager.GetAllOrder().Select(q => new OrderListVM()
            {
                Id = q.Id,
                OrderDate = q.OrderDate,
                OrderAddress = q.OrderAddress,
                OrderCode = q.OrderCode,
                webUserId = q.WebUserId,
                WebUser = q.WebUser,
                OrderDetails = OrderListManager.GetOrderDetailById(q.Id),
                TotalPrice = OrderListManager.OrderTotalPrice(q.Id),

            }).ToList();

            return View(OrderList);
            
        }

        public IActionResult GetOrderDetail(int id)
        {
            List<OrderListDetailVM> OrderDetailList = OrderListManager.GetOrderDetailById(id).Select(q => new OrderListDetailVM()
            {
                Id = q.Id,
                OrderId = q.OrderId,
                ProductId = q.ProductId,
                Quantity = q.Quantity,
                Product = ProductManager.GetProductById(q.ProductId),
                OrderCode = OrderManager.GetOrderById(id).OrderCode,
                Price=q.Price,
                

            }).ToList();


            return Json(OrderDetailList);

        }
    }
}
