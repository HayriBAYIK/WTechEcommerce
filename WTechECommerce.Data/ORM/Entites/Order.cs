using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WTechECommerce.Data.ORM.Entites
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public int WebUserId { get; set; }
        public string OrderAddress { get; set; }

        [ForeignKey("WebUserId")]
        public WebUser WebUser { get; set; }
    }
}
