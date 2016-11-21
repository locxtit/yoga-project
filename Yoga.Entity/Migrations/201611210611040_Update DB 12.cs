namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Note", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Events", "OrganizerEmail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Events", "OrganizerAddress", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Notifies", "Content", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Orders", "Note", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Note", c => c.String(maxLength: 200));
            AlterColumn("dbo.Notifies", "Content", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Events", "OrganizerAddress", c => c.String(maxLength: 200));
            AlterColumn("dbo.Events", "OrganizerEmail", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "Note", c => c.String(maxLength: 400));
        }
    }
}
