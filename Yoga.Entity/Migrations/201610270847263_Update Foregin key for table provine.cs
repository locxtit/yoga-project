namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeginkeyfortableprovine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Provinces", "StatusId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Provinces", "StatusId");
            AddForeignKey("dbo.Provinces", "StatusId", "dbo.Status", "StatusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provinces", "StatusId", "dbo.Status");
            DropIndex("dbo.Provinces", new[] { "StatusId" });
            AlterColumn("dbo.Provinces", "StatusId", c => c.String());
        }
    }
}
