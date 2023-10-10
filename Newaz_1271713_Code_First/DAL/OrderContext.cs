using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Newaz_1271713_Code_First.Models;

namespace Newaz_1271713_Code_First.DAL
{
    public class OrderContext : DbContext
    {
        public OrderContext(): base("NewazDb_7")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderMaster> OrderMasters { get; set; }


    }
}