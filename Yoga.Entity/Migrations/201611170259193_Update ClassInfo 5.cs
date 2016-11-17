namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassInfo5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClassInfoes", "TotalDays", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClassInfoes", "TotalDays", c => c.Int(nullable: false));
        }
    }
}
