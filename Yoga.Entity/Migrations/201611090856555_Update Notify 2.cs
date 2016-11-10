namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNotify2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Notifies", "NotityId", "NotifyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifies", "NotityId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Notifies");
            DropColumn("dbo.Notifies", "NotifyId");
            AddPrimaryKey("dbo.Notifies", "NotityId");
        }
    }
}
