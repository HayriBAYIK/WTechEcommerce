using System;
using System.Globalization;

namespace WTechECommerce.UI.Models
{
    public class ProductCartItemVM
    {
        private decimal _unitPrice;

        public int Id { get; set; }
        public string MainImg { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UnitPrice
        {

            get
            {
                return _unitPrice.ToString("c", CultureInfo.GetCultureInfo("tr-TR"));
            }

            set
            {
                _unitPrice = Convert.ToDecimal(value);
            }

        }
        public int Quantity { get; set; }
    }
}
