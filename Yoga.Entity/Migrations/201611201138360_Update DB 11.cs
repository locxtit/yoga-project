namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassInfoes", "Reply", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassInfoes", "Reply");
        }
    }
}
