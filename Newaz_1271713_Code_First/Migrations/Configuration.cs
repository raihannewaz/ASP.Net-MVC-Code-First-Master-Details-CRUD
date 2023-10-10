namespace Newaz_1271713_Code_First.Migrations
{
    using Newaz_1271713_Code_First.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Newaz_1271713_Code_First.DAL.OrderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Newaz_1271713_Code_First.DAL.OrderContext context)
        {
            var categories = new List<Category>
            {
                new Category{CategoryName="Yamaha"},
                new Category{CategoryName="Honda"},
                new Category{CategoryName="TVS"}
            };
            categories.ForEach(s => context.Categories.AddOrUpdate(c => c.CategoryName, s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product{CategoryID=1, ProductName="MT-15"},
                new Product{CategoryID=1, ProductName="FZ-S"},
                new Product{CategoryID=2, ProductName="SP-Shine"},
                new Product{CategoryID=2, ProductName="X-Blade"},
                new Product{CategoryID=3, ProductName="Stryker"},
                new Product{CategoryID=3, ProductName="RTR"}
            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.ProductName, s));
            context.SaveChanges();
        }
    }
}
