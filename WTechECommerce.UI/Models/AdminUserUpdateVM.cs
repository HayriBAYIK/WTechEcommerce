using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WTechECommerce.UI.Models
{
    public class AdminUserUpdateVM
    {
        public int Id { get; set; }

        [Display(Name = "Admin Role")]
        public string drpRoles { get; set; }


        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        [Required(ErrorMessage = "Email is required")]
        public string EMail { get; set; }

       
    }
}
