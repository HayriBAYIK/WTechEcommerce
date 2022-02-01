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
        [Required(ErrorMessage = "Code alanı boş bırakılamaz")]
        public string Name { get; set; }
        public string urlSlug { get; set; }
        [Required(ErrorMessage ="Code alanı boş bırakılamaz")]
        public string Code { get; set; }
        
        public string Description { get; set; }
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
        [Required(ErrorMessage ="Fotoğraf girmeniz gereklidir.")]
        public string MainImgPath { get; set; }
        [Required(ErrorMessage = "Fotoğraf girmeniz gereklidir.")]
        public List<string> ImagePaths { get; set; }
    }
}




