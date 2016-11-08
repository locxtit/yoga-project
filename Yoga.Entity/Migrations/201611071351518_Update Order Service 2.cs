namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderService2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderServices", "Total", c => c.Double(nullable: false));
            AddColumn("dbo.OrderServices", "Note", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderServices", "Note");
            DropColumn("dbo.OrderServices", "Total");
        }
    }
}
