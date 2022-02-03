using System;
namespace WTechECommerce.UI.Models
{
    public class ProductCartItemVM
    {
        public int Id { get; set; }
        public string MainImg { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
