namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassInfo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassInfoes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClassInfoes", "TotalDays", c => c.Int(nullable: false));
            AlterColumn("dbo.ClassInfoes", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClassInfoes", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.ClassInfoes", "TotalDays");
            DropColumn("dbo.ClassInfoes", "CreatedDate");
        }
    }
}
