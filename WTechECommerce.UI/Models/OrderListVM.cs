using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.UI.Models
{
    public class OrderListVM
    {
        public int Id { get; set; }
       
        public DateTime OrderDate { get; set; }
        public string OrderAddress { get; set; }
        public string OrderCode { get; set; }
        public int webUserId { get; set; }
        public WebUser WebUser { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }


    }
}
