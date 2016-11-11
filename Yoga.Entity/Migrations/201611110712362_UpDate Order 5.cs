namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpDateOrder5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "ContactName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "ContactEmail", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "CustomerPhone", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CustomerPhone", c => c.String(maxLength: 12));
            AlterColumn("dbo.Orders", "ContactEmail", c => c.String(maxLength: 100));
            AlterColumn("dbo.Orders", "ContactName", c => c.String(maxLength: 100));
        }
    }
}
