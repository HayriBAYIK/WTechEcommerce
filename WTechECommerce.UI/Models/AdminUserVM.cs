using System.ComponentModel.DataAnnotations;

namespace WTechECommerce.UI.Models
{
    public class AdminUserVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
