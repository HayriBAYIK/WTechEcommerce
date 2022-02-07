using System;
using System.Collections.Generic;
using System.Text;

namespace WTechECommerce.Data.ORM.Entites
{
    public class AdminUser : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
