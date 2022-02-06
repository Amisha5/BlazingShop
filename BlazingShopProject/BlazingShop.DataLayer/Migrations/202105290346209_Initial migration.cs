namespace BlazingShop.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(),
                        ProductId = c.Int(nullable: false),
                        CustomerName = c.String(nullable: false, maxLength: 30),
                        CustomerEmail = c.String(),
                        CustPhoneNumber = c.Long(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        PId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ShadeColor = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        files = c.Binary(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Appointments", new[] { "ProductId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Appointments");
        }
    }
}
