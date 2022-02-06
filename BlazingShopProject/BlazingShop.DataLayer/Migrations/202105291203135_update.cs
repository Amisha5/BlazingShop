namespace BlazingShop.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "CustomerEmail", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "CustomerEmail", c => c.String());
        }
    }
}
