using System;
using System.Globalization;

namespace WTechECommerce.UI.Models
{
    public class ProductVM
    {

        public int Id { get; set; }
        private decimal _unitPrice = 0;

        public string Name { get; set; }
        public string urlSlug { get; set; }
        public string UnitPrice {

            get
            {
                return _unitPrice.ToString("c", CultureInfo.GetCultureInfo("tr-TR"));
            }

            set
            {
                _unitPrice = Convert.ToDecimal(value);
            }

        }
        public string MainImgPath { get; set; }
    }
}


//@item.UnitPrice.ToString("c", CultureInfo.GetCultureInfo("tr-TR"))
//public string Name   // property
//{
//    get { return name; }   // get method
//    set { name = value; }  // set method
//}


