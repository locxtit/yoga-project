namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassInfo3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassInfoes", "TryLearnDate", c => c.DateTime());
            AddColumn("dbo.ClassInfoes", "NumOfPaidDays", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassInfoes", "NumOfPaidDays");
            DropColumn("dbo.ClassInfoes", "TryLearnDate");
        }
    }
}
