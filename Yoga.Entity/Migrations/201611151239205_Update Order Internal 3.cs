namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderInternal3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderInternals", "Content", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.OrderInternals", "Payer", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderInternals", "Payer");
            DropColumn("dbo.OrderInternals", "Content");
        }
    }
}
