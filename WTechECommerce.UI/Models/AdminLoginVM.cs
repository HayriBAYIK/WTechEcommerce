using System;
using System.ComponentModel.DataAnnotations;

namespace WTechECommerce.UI.Models
{
    public class AdminLoginVM
    {
        [Required(ErrorMessage ="EMail alanı boş geçilemez")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Password alanı boş geçilemez")]
        public string Password { get; set; }
    }
}
