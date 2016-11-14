namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassInfoAddColumnCompletePayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassInfoes", "CompletedPayment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassInfoes", "CompletedPayment");
        }
    }
}
