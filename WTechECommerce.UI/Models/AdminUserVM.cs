using System.ComponentModel.DataAnnotations;

namespace WTechECommerce.UI.Models
{
    public class AdminUserVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
