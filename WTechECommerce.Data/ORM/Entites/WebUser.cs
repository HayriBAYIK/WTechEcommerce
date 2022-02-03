using System;
using System.Collections.Generic;
using System.Text;

namespace WTechECommerce.Data.ORM.Entites
{
    public class WebUser : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsGuest { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
