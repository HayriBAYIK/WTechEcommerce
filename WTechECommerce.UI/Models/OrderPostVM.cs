using System;
using System.ComponentModel.DataAnnotations;

namespace WTechECommerce.UI.Models
{
    public class OrderPostVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string OrderAddress { get; set; }
    }
}
