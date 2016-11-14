namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderColumnOrderCode : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", "IX_Email");
            AlterColumn("dbo.Orders", "OrderCode", c => c.String(maxLength: 15));
            CreateIndex("dbo.Orders", "OrderCode", unique: true, name: "IX_Email");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", "IX_Email");
            AlterColumn("dbo.Orders", "OrderCode", c => c.String(maxLength: 10));
            CreateIndex("dbo.Orders", "OrderCode", unique: true, name: "IX_Email");
        }
    }
}
