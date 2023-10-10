namespace Newaz_1271713_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderInitialWithSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.OrderMasters", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.OrderMasters",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderNote = c.String(maxLength: 50),
                        OrderDate = c.DateTime(nullable: false),
                        AddressProofImage = c.String(),
                        Terms = c.Boolean(),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.OrderMasters");
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropTable("dbo.Products");
            DropTable("dbo.OrderMasters");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Categories");
        }
    }
}
