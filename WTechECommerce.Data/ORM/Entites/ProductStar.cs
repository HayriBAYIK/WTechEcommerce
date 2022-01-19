using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WTechECommerce.Data.ORM.Entites
{
    public class ProductStar : BaseEntity
    {
        public int ProductId { get; set; }
        public int Point { get; set; }
        public int WebUserId { get; set; }

        [ForeignKey("WebUserId")]
        public WebUser WebUser { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
