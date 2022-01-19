using System;
using Microsoft.EntityFrameworkCore;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.Data.ORM.Context
{
    public class WTechECommerceContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=94.73.150.5; Database=u9751868_db81F; UID=u9751868_user81F; PWD=XJgg29W0XZwn02S");


            //optionsBuilder.UseSqlServer(@"Server=.; Database=hayriDb; Trusted_connection=true");
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductComments> ProductComments { get; set; }
        public DbSet<ProductStar> ProductStars { get; set; }


    }
}
