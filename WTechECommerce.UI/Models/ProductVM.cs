using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WTechECommerce.UI.Models
{
    public class ProductVM
    {

        public int Id { get; set; }
       
        private decimal _unitPrice = 0;
      
        public string Name { get; set; }
        public string urlSlug { get; set; }
        public string Description { get; set; }

        public string Code { get; set; }
        
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
      
        public List<string> ImagePaths { get; set; }
    }
}




