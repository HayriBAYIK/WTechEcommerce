using System;
using Microsoft.EntityFrameworkCore;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.Data.ORM.Context
{
    public class WTechECommerceContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=94.73.150.3; Database=u9751868_db1EB; UID=u9751868_user1EB; PWD=Pf5GeCA55kYgy722Hj");


            //optionsBuilder.UseSqlServer(@"Server=.; Database=hayriDb; Trusted_connection=true");
        }


        public DbSet<Category> Categories { get; set; }
    }
}
