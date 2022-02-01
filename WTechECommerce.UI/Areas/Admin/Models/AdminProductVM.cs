using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WTechECommerce.UI.Areas.Admin.Models
{
    public class AdminProductVM
    {
        [Required(ErrorMessage = "Name alanı boş bırakılamaz")]
        [Display(Name ="Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fiyat alanı boş bırakılamaz")]
        [Display(Name = "Fiyat")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Kod")]
        public string Code { get; set; }

        //Ekranımda bir adet category dropdown olmak zorunda
        [Display(Name="Kategori")]
        public List<CategoryVM> drpCategories { get; set; }

        public int CategoryId { get; set; }

        [Display(Name="Ana Ürün Resmi")]
        public IFormFile MainProductImg { get; set; }

        [Display(Name = "Ürün Resimleri")]
        public List<IFormFile> ProductImages { get; set; }
    }
}
