namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderServices",
                c => new
                    {
                        OrderServiceId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        PaymentStatusId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderServiceId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentStatus", t => t.PaymentStatusId)
                .Index(t => t.CustomerId)
                .Index(t => t.PaymentStatusId);
            
            CreateTable(
                "dbo.PaymentStatus",
                c => new
                    {
                        PaymentStatusId = c.String(nullable: false, maxLength: 128),
                        PaymentStatusName = c.String(),
                    })
                .PrimaryKey(t => t.PaymentStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderServices", "PaymentStatusId", "dbo.PaymentStatus");
            DropForeignKey("dbo.OrderServices", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderServices", new[] { "PaymentStatusId" });
            DropIndex("dbo.OrderServices", new[] { "CustomerId" });
            DropTable("dbo.PaymentStatus");
            DropTable("dbo.OrderServices");
        }
    }
}
