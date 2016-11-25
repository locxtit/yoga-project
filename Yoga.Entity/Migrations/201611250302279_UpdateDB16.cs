namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassInfoes", "NotifyId", c => c.Int());
            CreateIndex("dbo.ClassInfoes", "NotifyId");
            AddForeignKey("dbo.ClassInfoes", "NotifyId", "dbo.Notifies", "NotifyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassInfoes", "NotifyId", "dbo.Notifies");
            DropIndex("dbo.ClassInfoes", new[] { "NotifyId" });
            DropColumn("dbo.ClassInfoes", "NotifyId");
        }
    }
}
