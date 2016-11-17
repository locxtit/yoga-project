namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifies", "Description", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Notifies", "Content", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifies", "Content", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Notifies", "Description", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
