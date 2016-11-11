namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Price");
        }
    }
}
