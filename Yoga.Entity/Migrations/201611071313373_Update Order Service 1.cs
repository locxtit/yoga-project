namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderService1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderServices", "PaymentStatusId", "dbo.PaymentStatus");
            DropIndex("dbo.OrderServices", new[] { "PaymentStatusId" });
            DropPrimaryKey("dbo.PaymentStatus");
            AlterColumn("dbo.OrderServices", "PaymentStatusId", c => c.String(maxLength: 50));
            AlterColumn("dbo.PaymentStatus", "PaymentStatusId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PaymentStatus", "PaymentStatusName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Services", "ServiceName", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.PaymentStatus", "PaymentStatusId");
            CreateIndex("dbo.OrderServices", "PaymentStatusId");
            AddForeignKey("dbo.OrderServices", "PaymentStatusId", "dbo.PaymentStatus", "PaymentStatusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderServices", "PaymentStatusId", "dbo.PaymentStatus");
            DropIndex("dbo.OrderServices", new[] { "PaymentStatusId" });
            DropPrimaryKey("dbo.PaymentStatus");
            AlterColumn("dbo.Services", "ServiceName", c => c.String());
            AlterColumn("dbo.PaymentStatus", "PaymentStatusName", c => c.String());
            AlterColumn("dbo.PaymentStatus", "PaymentStatusId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderServices", "PaymentStatusId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.PaymentStatus", "PaymentStatusId");
            CreateIndex("dbo.OrderServices", "PaymentStatusId");
            AddForeignKey("dbo.OrderServices", "PaymentStatusId", "dbo.PaymentStatus", "PaymentStatusId");
        }
    }
}
