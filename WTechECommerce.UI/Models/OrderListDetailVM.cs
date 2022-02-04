using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.UI.Models
{
    public class OrderListDetailVM
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public string OrderCode { get; set; }
    }
}
