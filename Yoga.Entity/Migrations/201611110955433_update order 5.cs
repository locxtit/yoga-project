namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorder5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaymentDate", c => c.DateTime());
            AddColumn("dbo.Orders", "PriceForTrainer", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "TotalPaidForTrainer", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalPaidForTrainer");
            DropColumn("dbo.Orders", "PriceForTrainer");
            DropColumn("dbo.Orders", "PaymentDate");
        }
    }
}
